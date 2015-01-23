using UnityEngine;
using System.Collections;

public class Shooting : CharacterInput 
{
	private static Shooting instance;
	public static Shooting Instance{
		get{ return instance; }
	}

	public static int shootMode = 0;

	public static GameObject projectile;
	private static float delay = 0.5f;
	private bool countdown;
	private float timer;

	//public Transform target;
	public float maxAngle = 35.0f;
	private Quaternion baseRotation;
	private Quaternion targetRotation;
	public AudioClip shootAudio;

	public static float Delay
	{
		get{ return delay; }
		set{ delay = value; delay = Mathf.Clamp( delay, 0.075f, 1.5f ); }
	}

	public void ShootMode( int mode, float time )
	{
		SetMode(mode);
		StartCoroutine( EndShootMode(time) );
	}
	IEnumerator EndShootMode( float time )
	{
		yield return new WaitForSeconds( time );
		SetMode(0);
	}

	void SetMode( int mode )
	{
		shootMode = mode;
		switch( mode )
		{
		case 1:
			Delay = 0.35f;
			break;
		case 2:
			Delay = 0.2f;
			break;
		default:
			Delay = 0.425f;
			shootMode = 0;
			break;
		}
	}

	// Use this for initialization
	void Start () 
	{
		instance = this;
		projectile = Resources.Load("Prefabs/Bullets/BaseProjectile") as GameObject;
		timer = delay;
		baseRotation = transform.rotation;
		LookAtTarget( transform.position + new Vector3( -10, 0, 0 ) );
	}
	void OnApplicationExit(){
		SetMode (0);
	}
	void OnLevelWasLoaded( int val ){
		SetMode (0);
	}

	
	// Update is called once per frame
	void Update () 
	{
		LookAtMouse();

		if(countdown){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			countdown = false;
		}
		if( GetShootInput() && !countdown )
		{
			countdown = true;
			timer = delay;
			Shoot ();

			/*
			Vector2 spawnPos = VectorExtras.OffsetPosInPointDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z), 0.6f );
			GameObject proj = (GameObject)Instantiate( projectile, new Vector3( spawnPos.x, 1.0f, spawnPos.y ), Quaternion.identity );
			Vector2 dir = VectorExtras.Direction( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z) );
			proj.GetComponent<Projectile>().direction = new Vector3( dir.x, 0.0f, dir.y );
			proj.GetComponent<Projectile>().speed += PlyMovement.speed; */
		}
	}
	void Shoot()
	{
		Utils.Audio.AudioHelper.PlayClipAtPoint(shootAudio, transform.position, Utils.Audio.AudioHelper.EffectVolume);
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			//hit.collider.renderer.material.color = Color.red;
		}
		else
			Debug.Log ("Nothing was hit!", this);

		LookAtTarget( hit.point );

		Vector2[] spawnPos = new Vector2[3];
		spawnPos[0] = VectorExtras.OffsetPosInDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(transform.forward.x, transform.forward.z), 0.6f );
		spawnPos[1] = VectorExtras.OffsetPosInDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(transform.forward.x, transform.forward.z), 0.6f );
		spawnPos[2] = VectorExtras.OffsetPosInDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(transform.forward.x, transform.forward.z), 0.6f );
		if(shootMode == 1){
			spawnPos[0].y = Main.player.transform.position.z - 0.25f;
			spawnPos[1].y = Main.player.transform.position.z + 0.25f;
			GameObject proj1 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[0].x, 1.0f, spawnPos[0].y ), Quaternion.identity );
			GameObject proj2 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[1].x, 1.0f, spawnPos[1].y ), Quaternion.identity );
			Vector3 dir = transform.forward + new Vector3(0, 0, -0.125f);
			Vector3 rightDir = transform.forward + new Vector3(0, 0, 0.125f);
			proj1.GetComponent<Projectile>().direction = dir;
			proj1.GetComponent<Projectile>().speed += PlyMovement.Speed;
			proj2.GetComponent<Projectile>().direction = rightDir;
			proj2.GetComponent<Projectile>().speed += PlyMovement.Speed;
		} else if(shootMode == 2){
			spawnPos[1].y = Main.player.transform.position.z + 0.75f;
			spawnPos[2].y = Main.player.transform.position.z - 0.75f;
			GameObject proj1 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[0].x, 1.0f, spawnPos[0].y ), Quaternion.identity );
			GameObject proj2 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[1].x, 1.0f, spawnPos[1].y ), Quaternion.identity );
			GameObject proj3 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[2].x, 1.0f, spawnPos[2].y ), Quaternion.identity );
			Vector3 dir = transform.forward;
			Vector3 rightDir = transform.forward + new Vector3(0, 0, -0.125f);
			Vector3 leftDir = transform.forward + new Vector3(0, 0, 0.125f);;
			proj1.GetComponent<Projectile>().direction = dir;
			proj1.GetComponent<Projectile>().speed += PlyMovement.Speed;
			proj2.GetComponent<Projectile>().direction = leftDir;
			proj2.GetComponent<Projectile>().speed += PlyMovement.Speed;
			proj3.GetComponent<Projectile>().direction = rightDir;
			proj3.GetComponent<Projectile>().speed += PlyMovement.Speed;
		} else {
			GameObject proj1 = (GameObject)Instantiate( projectile, new Vector3( spawnPos[0].x, 1.0f, spawnPos[0].y ), Quaternion.identity );
			Vector3 dir = transform.forward;
			proj1.GetComponent<Projectile>().direction = dir;
			proj1.GetComponent<Projectile>().speed += PlyMovement.Speed;
		}
	}
	void LookAtTarget(Vector3 target)
	{
		target.x -= maxAngle;
		Vector3 look = target - transform.position;
		look.y = 0;

		Quaternion q = Quaternion.LookRotation (look);
		if (Quaternion.Angle (q, baseRotation) <= maxAngle)
			targetRotation = q;
		
		transform.rotation = targetRotation;//Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
	}
	void LookAtMouse()
	{
		RaycastHit hit;
		Ray ray = GetSwipe() == 2 ? sRay : Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			//hit.collider.renderer.material.color = Color.red;
		}
		//else
			//Debug.Log ("Nothing was hit!", this);

		LookAtTarget( hit.point );
	}
}
