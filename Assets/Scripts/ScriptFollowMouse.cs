using UnityEngine;
using System.Collections;

public class ScriptFollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 mouse_pos = Input.mousePosition;
		Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(mouse_pos.y - object_pos.y, mouse_pos.x - object_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
	}
}
