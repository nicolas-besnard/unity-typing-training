using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour 
{
	public GameObject		hitPrefab = null;
	public AudioClip		hitSound = null;
	
	void 					Start () 
	{
	
	}
	

	void 					Update () 
	{
	
	}
	
	public void				isHit()
	{
		playParticleCollision();
		playHitSound();
	}
	
	void					playParticleCollision()
	{
		if (hitPrefab != null)
		{
			Vector3 particlePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject particle = Instantiate(hitPrefab, particlePosition, Quaternion.identity) as GameObject;
			Destroy(particle, .5f);
		}	
	}
	
	void					playHitSound()
	{
		if (hitSound != null)
		{
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
		}
	}
	
}
