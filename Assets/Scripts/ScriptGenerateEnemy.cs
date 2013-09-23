using UnityEngine;
using System.Collections;
using System.IO;

public class ScriptGenerateEnemy : MonoBehaviour 
{
	public GameObject				enemyPrefab;
	public TextAsset				dictionnary;
	
	float							timer = .0f;
	float							timerTotal = 1.0f;
	float							totalEnemy = 100;
	int								enemyCount = 0;
	
	string[][]						words = new string[2][];
	int								nbDifferentLenWords = 0;
	
	// Use this for initialization
	void 							Start () 
	{
		TextAsset word1 = Resources.Load("word1") as TextAsset;
		TextAsset word2 = Resources.Load("word2") as TextAsset;
		
		fillStringArray(word1);
		fillStringArray(word2);
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
	
	void							fillStringArray(TextAsset text)
	{
		int 						nbWord = text.text.Split(',').Length;
		int 						countWord = 0;
		
		words[nbDifferentLenWords] = new string[nbWord];
		
		foreach(string str in text.text.Split(','))
		{
			words[nbDifferentLenWords][countWord] = str;
			++countWord;
		}
		++nbDifferentLenWords;
	}
	
	void 							spawnEnemy()
	{
		Vector3 					position = new Vector3(
			Random.Range(-16, 16),
			transform.position.y,
			0
		);
		
		int							level = Random.Range(0, 2);
		int							word = Random.Range(0, words[level].Length);
		
		GameObject enemy = (GameObject)(Instantiate(enemyPrefab, position, Quaternion.identity));
		enemy.transform.rotation = new Quaternion(enemy.transform.rotation.x, enemy.transform.rotation.y, 180, enemy.transform.rotation.w);
		enemy.GetComponent<ScriptEnemy>().word = words[level][word];		
	}
}
