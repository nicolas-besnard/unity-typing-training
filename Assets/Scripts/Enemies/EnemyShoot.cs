using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour 
{
	public GameObject		missilePrefab;
	
	public float			shootDelay = 5.0f;
	float					shootTimer = 0.0f;

	void 					Start () 
	{
		initShootTimer();
	}
	
	// Update is called once per frame
	void 					Update () 
	{
		shootTimer -= Time.deltaTime;
		
		if (shootTimer <= 0)
		{
			initShootTimer();
			shoot();
		}
	}
	
	void					initShootTimer()
	{
		shootTimer = shootDelay;
	}
	
	void					shoot()
	{
		GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation) as GameObject;
		
		missile.GetComponent<Word>().word = GameObject.Find("_GameManager").GetComponent<WordsManager>().getRandomWord();
	}
}
