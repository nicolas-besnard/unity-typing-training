using UnityEngine;
using System.Collections;

public class GoToPlayer : MonoBehaviour 
{
	public GameObject		player;
	public float			speed = 1.0f;
	
	float					distanceTraveled = 0.0f;
	Vector3					startPoint;
	float					totalDistance;

	// Use this for initialization
	void 					Start () 
	{
		startPoint = transform.position;
		totalDistance = Vector3.Distance(transform.position, player.transform.position);
	}
	
	// Update is called once per frame
	void 					Update () 
	{
		distanceTraveled += speed * Time.deltaTime;
	
		transform.position = Vector3.Lerp(
			startPoint,
			player.transform.position,
			distanceTraveled / totalDistance
		);
	}
}
