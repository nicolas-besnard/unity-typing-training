using UnityEngine;
using System.Collections;

public class ScriptMissile : MonoBehaviour 
{
	public GameObject		target;
	public Vector3			startPoint;
	public float			totalDistance;
	
	float					distanceTraveled = 0.0f;
	float					speed = 30.0f;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO: change update by adding Force to rigibBody
		distanceTraveled += speed * Time.deltaTime;
		
		transform.position = Vector3.Lerp(
											startPoint,
											target.transform.position,
											distanceTraveled / totalDistance
											);
		
		if (distanceTraveled >= totalDistance - 1)
		{
			target.GetComponent<ScriptEnemy>().isHit();	
			Destroy(gameObject);	
		}
							
	}
}
