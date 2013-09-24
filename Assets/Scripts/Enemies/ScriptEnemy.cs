using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Word))]
[RequireComponent(typeof(Hit))]
public class ScriptEnemy : MonoBehaviour 
{
	int						hitCount = 0;
	int						wordLength;
	float					timerHit = .0f; // current timer
	float					timerHitTotal = .2f; // Time enemy go back when hit
	float					speed = 1.0f;
	public TextMesh			textBox;
	
	GoToPlayer				GoToPlayerComponent; // GoToPlayer component
	Word					word; // Word component
	Hit						hit; // Hit component
		
	public void				deleteCurrentChar()
	{
		word.word = word.word.Substring(1);
		textBox.text = word.word;
		if (word.word.Length == 0)
		{
			GameObject
				.FindGameObjectWithTag("Player")
				.GetComponent<ScriptPlayer>()
				.lastHitOnEnemy();
		}	
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
		
		if (word.word.Length == 0)
			return false;
		return word.word[0] == c;	
	}
	
	/*
	 * When enemy is hit
	 */
	
	public void				isHit()
	{
		hit.isHit();
		++hitCount;

		if (speed > 0)
		{
			speed *= -1;
			timerHit = timerHitTotal;
		}
		
		if (hitCount == wordLength)
		{
			die ();	
		}	
	}
	
	
	// Use this for initialization
	void 					Start ()
	{
		word = gameObject.GetComponent<Word>();
		hit  = gameObject.GetComponent<Hit>();
		textBox = transform.GetComponentInChildren<TextMesh>();
		textBox.text = word.word;
		wordLength = word.word.Length;	
	}
	
	// Update is called once per frame
	void 					Update () 
	{
		timerHit -= Time.deltaTime;
		if (timerHit <= 0)
		{
			speed = Mathf.Abs(speed);
		}
	}
	
	void 					die()
	{
		// Say to player that enemy is dead : don't target him anymore
		GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptPlayer>().lastHitOnEnemy();
		
		Destroy(gameObject);		
	}
}
