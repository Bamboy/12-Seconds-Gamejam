using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider),typeof(Rigidbody))]
public class NewTileTrigger : MonoBehaviour 
{
	void Awake () 
	{
		collider.isTrigger = true;
		rigidbody.useGravity = false;
	}
	
	void OnTriggerEnter( Collider c )
	{
		if( c.tag == "Player" )
		{
			Infinitetile.AddTile();
		}
	}
}
