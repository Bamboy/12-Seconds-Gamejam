using UnityEngine;
using Enemies;
using Utils;

public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 3.0f;
	public AudioSource onHit;
	public AudioClip[] hitFiles;
	public GameObject audioSource;

	void Start()
	{
		rigidbody.AddForce( direction * speed, ForceMode.Impulse );
	}
	
	void OnTriggerEnter(Collider col)
	{
		BaseEnemy enemy = col.GetComponent< BaseEnemy >();
		if( enemy != null )
		{
			enemy.OnTakeDamage( 1 );
		}

		Destroy(gameObject); 
	}
}