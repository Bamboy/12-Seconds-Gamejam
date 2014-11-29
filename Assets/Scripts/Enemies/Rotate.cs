using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public Vector3 rotation;
	public bool randomRotation;

	void Start()
	{
		if( randomRotation )
		{
			rotation = new Vector3( Random.Range(-360.0f,360.0f), Random.Range(-360.0f,360.0f), Random.Range(-360.0f,360.0f) );
		}
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate( rotation * Time.deltaTime );
	}
}
