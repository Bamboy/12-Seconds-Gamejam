using UnityEngine;
using Enemies;
using Utils.Audio;

public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 3.0f;

	public AudioClip impact1;
	public AudioClip impact2;
	private Vector3 newDirection;
	//private Color projectileOriginal;
	private ParticleSystem referenceObject;
	public Color powerup1;
	public Color powerup2;
	private int projType;

	void Start()
	{
		rigidbody.AddForce( direction * speed, ForceMode.Impulse );
		referenceObject = GetComponentInChildren<ParticleSystem>();
		//projectileOriginal = referenceObject.startColor;

		projType = Shooting.shootMode;
		switch( projType )
		{
		case 1:
			renderer.material.color = powerup1;
			referenceObject.startColor = powerup1;
			break;
		case 2:
			renderer.material.color = powerup2;
			referenceObject.startColor = powerup2;
			break;
		default:
			break;
		}
		/*if(Infinitetile.Area == 0){
			referenceObject.startColor = projectileOriginal;
		} else if(Infinitetile.Area == 1){
			referenceObject.startColor = Color.red;
		} else if(Infinitetile.Area == 2){
			referenceObject.startColor = projectileOriginal;
		} else if(Infinitetile.Area == 3){
			referenceObject.startColor = Color.green;
		}*/
	}

	void OnTriggerEnter(Collider col)
	{
		BaseEnemy enemy = col.GetComponent< BaseEnemy >();
		if( enemy != null )
		{
			enemy.OnTakeDamage( GetDamage() );
		}

		if( !(enemy is Wave) ) //Ingore waves.
		{
			PlayImpact();
			//if(Infinitetile.Area == 3 || Infinitetile.Area == 1)
			//{
			newDirection = new Vector3(-1f, 0f, Random.Range(-1f, 1f));
			rigidbody.AddForce(newDirection * speed, ForceMode.Impulse);
			Destroy(gameObject, 5f);
			//} else {
			//	Destroy(gameObject);
			//}
		}
	}

	int GetDamage()
	{
		switch (projType)
		{
		case 1:
			return 3;
		case 2:
			return 2;
		default:
			return 1;
		}
	}


	void PlayImpact()
	{
		if( VectorExtras.SplitChance() )
		{
			AudioHelper.PlayClipAtPoint( impact1, transform.position, 0.8f, SoundType.Effect );
		}
		else
		{
			AudioHelper.PlayClipAtPoint( impact2, transform.position, 0.8f, SoundType.Effect );
		}
	}





}