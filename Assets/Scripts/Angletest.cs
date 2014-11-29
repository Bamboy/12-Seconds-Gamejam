using UnityEngine;
using System.Collections;

public class Angletest : MonoBehaviour 
{
	/*
	public Transform player;
	public float angle;
	public Vector2 vec;
	public float dot;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		dot = Vector3.Dot( transform.TransformDirection(Vector3.forward), player.TransformDirection(Vector3.forward) );
	} */

	public Transform target;
	public float maxAngle = 35.0f;
	private Quaternion baseRotation;
	private Quaternion targetRotation;
	
	
	void Start() {
		baseRotation = transform.rotation;
	}
	
	void Update() {
		
		Vector3 look = target.transform.position - transform.position;
		look.y = 0;
		
		Quaternion q = Quaternion.LookRotation (look);
		if (Quaternion.Angle (q, baseRotation) <= maxAngle)
			targetRotation = q;
		
		transform.rotation = targetRotation;//Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
	}
}
