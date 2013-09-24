using UnityEngine;
using System.Collections;

public class ScriptOppressorBullet : MonoBehaviour 
{
	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.Translate (Vector3.up * 2f * Time.deltaTime);
	}
}
