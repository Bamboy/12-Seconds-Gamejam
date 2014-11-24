using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 3.0f;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate( direction * speed * Time.deltaTime );
	}


}
