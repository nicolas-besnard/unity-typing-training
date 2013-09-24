using UnityEngine;
using System.Collections;

public class ScriptOppressor : MonoBehaviour 
{
	public GameObject			bullet;
	bool 						hasSpawn = false;
	
	void 						Start () 
	{
	
	}
	
	void 						Update () 
	{
		if (!hasSpawn)
		{
			float angle = Mathf.PI ;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.down);
			Vector3 position = new Vector3(
				transform.position.x + 1.5f,
				transform.position.y + 1.5f,
				0
			);
			GameObject bullet1 = Instantiate(bullet, position, rotation) as GameObject;
			bullet1.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, 10.0f);

			hasSpawn = true;
		}
	}
}
