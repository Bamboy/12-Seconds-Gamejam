﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
	public GameObject projectile;
	public float shootDelay = 0.75f;
	private bool countdown;
	private float timer;

	//public Transform target;
	public float maxAngle = 35.0f;
	private Quaternion baseRotation;
	private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		timer = shootDelay;
		baseRotation = transform.rotation;
		LookAtTarget( transform.position + new Vector3( -10, 0, 0 ) );
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
#if UNITY_STANDALONE
		if( Input.GetMouseButtonDown(0) && !countdown )
		{
			countdown = true;
			timer = shootDelay;
			Shoot ();

			/*
			Vector2 spawnPos = VectorExtras.OffsetPosInPointDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z), 0.6f );
			GameObject proj = (GameObject)Instantiate( projectile, new Vector3( spawnPos.x, 1.0f, spawnPos.y ), Quaternion.identity );
			Vector2 dir = VectorExtras.Direction( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z) );
			proj.GetComponent<Projectile>().direction = new Vector3( dir.x, 0.0f, dir.y );
			proj.GetComponent<Projectile>().speed += PlyMovement.speed; */
		}
#endif
#if UNITY_ANDROID
		foreach(Touch touch in Input.touches){
			if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && !countdown){
				countdown = true;
				timer = shootDelay;
				Shoot ();
				
				/*
				Vector2 spawnPos = VectorExtras.OffsetPosInPointDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z), 0.6f );
				GameObject proj = (GameObject)Instantiate( projectile, new Vector3( spawnPos.x, 1.0f, spawnPos.y ), Quaternion.identity );
				Vector2 dir = VectorExtras.Direction( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z) );
				proj.GetComponent<Projectile>().direction = new Vector3( dir.x, 0.0f, dir.y );
				proj.GetComponent<Projectile>().speed += PlyMovement.speed; */
			}
		}
#endif
	}
	void Shoot()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			//hit.collider.renderer.material.color = Color.red;
		}
		else
			Debug.Log ("Nothing was hit!", this);

		LookAtTarget( hit.point );

		Vector2 spawnPos = VectorExtras.OffsetPosInDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(transform.forward.x, transform.forward.z), 0.6f );
		GameObject proj = (GameObject)Instantiate( projectile, new Vector3( spawnPos.x, 1.0f, spawnPos.y ), Quaternion.identity );
		Vector3 dir = transform.forward;
		proj.GetComponent<Projectile>().direction = dir;
		proj.GetComponent<Projectile>().speed += PlyMovement.speed;
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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			//hit.collider.renderer.material.color = Color.red;
		}
		else
			Debug.Log ("Nothing was hit!", this);

		LookAtTarget( hit.point );
	}
}
