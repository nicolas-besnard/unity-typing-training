using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ScriptPlayer : MonoBehaviour 
{
	public GameObject		prefabMissile;
	public AudioClip		shootSound;
	
	GameObject 				currentTarget = null;
	string 					unConsumedChar = "";
	
	// Use this for initialization
	void 					Start () 
	{
	
	}
		
	void					Update () 
	{
		foreach (char c in Input.inputString) 
		{
			unConsumedChar += c;
		}
		if (unConsumedChar.Length == 0)
			return ;			
		
		int currentChar = getNextChar();
		
		// No actual target
		if (currentTarget == null)
		{
			// There's a target with for current char
			if (anEnemyHasChar((char)(currentChar)))
			{				
				ArrayList 	enemies = getEnemyWithChar((char)(currentChar));
				GameObject 	nearestEnemy = null;
				float		nearestDistance = 10000;
			
				foreach (GameObject enemy in enemies)
				{
					Vector3 enemyPosition = enemy.transform.position;
					float distancePlayerEnemy = Vector3.Distance(enemyPosition, transform.position);
					
					
					if (distancePlayerEnemy < nearestDistance)
					{
						nearestDistance = distancePlayerEnemy;
						nearestEnemy = enemy;						
					}
				}
				if (nearestEnemy)
				{
					currentTarget = nearestEnemy;
					currentTarget.GetComponent<ScriptEnemy>().textBox.color = Color.red;
					Vector3 mouse_pos = Camera.main.WorldToScreenPoint(currentTarget.transform.position);
					Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
					float angle = Mathf.Atan2(mouse_pos.y - object_pos.y, mouse_pos.x - object_pos.x) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
				}
			}
		}
		
		if (currentTarget)
		{	
			// current target has char
			if (currentTarget.GetComponent<ScriptEnemy>().firstCharIs((char)(currentChar)))
			{
				shoot ();
				currentTarget.GetComponent<ScriptEnemy>().deleteCurrentChar();
			}
		}
	}
	
	void 					shoot()
	{
		GameObject missileObject = (GameObject)(Instantiate(prefabMissile));
			
		missileObject.transform.rotation = transform.rotation;
		missileObject.transform.position = transform.position;
		
		ScriptMissile missile = missileObject.GetComponent<ScriptMissile>();
		missile.target = currentTarget;
		missile.startPoint = transform.position;
		missile.totalDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
		audio.PlayOneShot(shootSound);
	}
	
	public void				lastHitOnEnemy()
	{
		currentTarget = null;
	}
		
	
	/*
	 * Check whether an enemy has a specific char
	 * 
	 * @param	char c	char to check
	 * @return	bool
	 */
	
	bool					anEnemyHasChar(char c)
	{
		GameObject[] 		enemies = GameObject.FindGameObjectsWithTag("enemy");
		
		foreach(GameObject enemy in enemies)
		{
			if (enemy.GetComponent<ScriptEnemy>().firstCharIs(c))
			{
				return true;	
			}
		}
		return false;
	}
	
	
	/*
	 * List all enemy who has a specific char
	 *
	 * @param	char c	char to check
	 * @return	ArrayList
	 */
	
	ArrayList				getEnemyWithChar(char c)
	{
		ArrayList			ret = new ArrayList();
		GameObject[] 		enemies = GameObject.FindGameObjectsWithTag("enemy");
		
		foreach(GameObject enemy in enemies)
		{
			if (enemy.GetComponent<ScriptEnemy>().firstCharIs(c))
			{
				ret.Add(enemy);
			}
		}
		return ret;
	}
	
	
	/*
	 * Get the next un-consumed char
	 * 
	 * @return int
	 */
	
	int						getNextChar()
	{
		if (unConsumedChar.Length > 0)
		{
			char 			c = unConsumedChar[0];
			
			unConsumedChar = unConsumedChar.Substring(1);
			return c;
		}
		return -1;
	}		
}
