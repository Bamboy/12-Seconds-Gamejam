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
	private Vector3 newDirection;
	private Color projectileOriginal;
	private ParticleSystem referenceObject;

	void Start()
	{
		rigidbody.AddForce( direction * speed, ForceMode.Impulse );
		referenceObject = GetComponentInChildren<ParticleSystem>();
		projectileOriginal = referenceObject.startColor;
		if(Infinitetile.Area == 0){
			referenceObject.startColor = projectileOriginal;
		} else if(Infinitetile.Area == 1){
			referenceObject.startColor = Color.red;
		} else if(Infinitetile.Area == 2){
			referenceObject.startColor = projectileOriginal;
		} else if(Infinitetile.Area == 3){
			referenceObject.startColor = Color.green;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		BaseEnemy enemy = col.GetComponent< BaseEnemy >();
		if( enemy != null )
		{
			enemy.OnTakeDamage( 1 );
		}

		if( !(enemy is Wave) ) //Ingore waves.
		{
			if(Infinitetile.Area == 3 || Infinitetile.Area == 1)
			{
				newDirection = new Vector3(-1f, 0f, Random.Range(-1f, 1f));
				rigidbody.AddForce(newDirection * speed, ForceMode.Impulse);
				Destroy(gameObject, 5f);
			} else {
				Destroy(gameObject);
			}
		}
	}
}