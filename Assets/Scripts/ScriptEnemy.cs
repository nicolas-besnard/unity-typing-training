using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ScriptEnemy : MonoBehaviour 
{
	public GameObject		player;
	public string 			word;
	public GameObject		hitPrefab = null;
	public AudioClip		hitSound = null;
	
	int						hitCount = 0;
	int						wordLength;
	float					timerHit = .0f; // current timer
	float					timerHitTotal = .2f; // Time enemy go back when hit
	
	public TextMesh			textBox;
	
	GoToPlayer				GoToPlayerComponent; //GoToPlayer component
	
	/*
	 * Check if first letter of an enemy is a gived char
	 * 
	 * If enemy has the char, remove the letter
	 * 
	 * @param	char	checked char
	 * 
	 * @return	bool
	 */
	
	public bool 			hasChar(char c)
	{
		if (firstCharIs(c))
		{
			word = word.Substring(1);
			textBox.text = word;
			if (word.Length == 0)
			{
				GameObject
					.FindGameObjectWithTag("Player")
					.GetComponent<ScriptPlayer>()
					.canHitAnOtherEnemy();
			}
			return true;
		}
		return false;
	}
	
	/*
	 * Check if first char in string is a gived char
	 * 
	 * @param 	char
	 * 
	 * @return	bool
	 */
	
	public bool 			firstCharIs(char c)
	{
		if (word.Length == 0)
			return false;
		return word[0] == c;	
	}
	
	/*
	 * When enemy is hit
	 */
	
	public void				isHit()
	{
		playHitSound();
		playParticleCollision();
		++hitCount;
		

		if (GoToPlayerComponent.speed > 0)
		{
			GoToPlayerComponent.speed *= -1;
			timerHit = timerHitTotal;
		}
		
		if (hitCount == wordLength)
		{
			die ();	
		}	
	}
	
	void					playParticleCollision()
	{
		if (hitPrefab != null)
		{
			Vector3 particlePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject particle = Instantiate(hitPrefab, particlePosition, Quaternion.identity) as GameObject;
			Destroy(particle, .5f);
		}	
	}
	
	void					playHitSound()
	{
		if (hitSound != null)
		{
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
		}
	}
	
	
	// Use this for initialization
	void 					Start ()
	{	

		GoToPlayerComponent = gameObject.GetComponent<GoToPlayer>();

		textBox = transform.GetComponentInChildren<TextMesh>();
		textBox.text = word;
		wordLength = word.Length;	
	}
	
	// Update is called once per frame
	void 					Update () 
	{
		timerHit -= Time.deltaTime;
		if (timerHit <= 0)
		{
			float speed = GoToPlayerComponent.speed;
			speed = Mathf.Abs(speed);
			
			GoToPlayerComponent.speed = speed;
		}
	}
	
	void 					die()
	{
		// Say to player that enemy is dead : don't target him anymore
		GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptPlayer>().lastHitOnEnemy();
		
		Destroy(gameObject);		
	}
}
