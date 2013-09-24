using UnityEngine;
using System.Collections;

public class ScriptEnemyMovement : MonoBehaviour 
{

	void Start () 
	{
	
	}
	
	void Update () 
	{
		 transform.position += transform.up * 1.0f * Time.deltaTime;
	}
}
