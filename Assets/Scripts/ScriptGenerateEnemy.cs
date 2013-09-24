using UnityEngine;
using System.Collections;
using System.IO;

public class ScriptGenerateEnemy : MonoBehaviour 
{
	public GameObject				enemyPrefab;
	
	float							timer = .0f;
	float							timerTotal = 1.0f;
	float							totalEnemy = 100;
	int								enemyCount = 0;
	WordsManager					wordsManager;
	
	// Use this for initialization
	void 							Start () 
	{
		wordsManager = GameObject.Find("_GameManager").GetComponent<WordsManager>();
		if (wordsManager)
		{
			Debug.Log (wordsManager.getRandomWord());	
		}
	}
	
	// Update is called once per frame
	void 							Update () 
	{
		timer -= Time.deltaTime;
		
		if (timer <= 0 && enemyCount < totalEnemy)
		{
			timer = timerTotal;
			spawnEnemy();
			++enemyCount;
		}
	}
	
	
	void 							spawnEnemy()
	{
		Vector3 					position = new Vector3(
			Random.Range(-16, 16),
			transform.position.y,
			0
		);
				
		GameObject enemy = (GameObject)(Instantiate(enemyPrefab, position, Quaternion.identity));
		enemy.transform.rotation = new Quaternion(enemy.transform.rotation.x, enemy.transform.rotation.y, 180, enemy.transform.rotation.w);
		enemy.GetComponent<Word>().word = wordsManager.getRandomWord();
	}
}
