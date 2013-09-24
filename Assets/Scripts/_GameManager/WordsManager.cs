using UnityEngine;
using System.Collections;

public class WordsManager : MonoBehaviour 
{
	string[][]				words = new string[12][];
	int						nbDifferentLenWords = 0;
	
	void 					Start () 
	{
		TextAsset word2 = Resources.Load("word2") as TextAsset;
		TextAsset word3 = Resources.Load("word3") as TextAsset;
		TextAsset word4 = Resources.Load("word4") as TextAsset;
		TextAsset word5 = Resources.Load("word5") as TextAsset;
		TextAsset word6 = Resources.Load("word6") as TextAsset;
		TextAsset word7 = Resources.Load("word7") as TextAsset;
		TextAsset word8 = Resources.Load("word8") as TextAsset;
		TextAsset word9 = Resources.Load("word9") as TextAsset;
		TextAsset word10 = Resources.Load("word10") as TextAsset;
		TextAsset word11 = Resources.Load("word11") as TextAsset;
		TextAsset word12 = Resources.Load("word12") as TextAsset;
		
		fillStringArray(word2);
		fillStringArray(word3);
		fillStringArray(word4);
		fillStringArray(word5);
		fillStringArray(word6);
		fillStringArray(word7);
		fillStringArray(word8);
		fillStringArray(word9);
		fillStringArray(word10);
		fillStringArray(word11);
		fillStringArray(word12);
	}
	
	void 					Update () 
	{
	
	}
	
	void					fillStringArray(TextAsset text)
	{
		int 				nbWord = text.text.Split(',').Length;
		int 				countWord = 0;
		
		words[nbDifferentLenWords] = new string[nbWord];
		
		foreach(string str in text.text.Split(','))
		{
			words[nbDifferentLenWords][countWord] = str;
			++countWord;
		}
		++nbDifferentLenWords;
	}
	
	public string			getRandomWord()
	{
		int					level = Random.Range(0, nbDifferentLenWords);
		int					word = Random.Range(0, words[level].Length);

		return words[level][word];
	}
}
