using UnityEngine;
using System.Collections;
using Enemies;

public class DragonStart : MonoBehaviour 
{
	void Awake () 
	{
		collider.isTrigger = true;
		rigidbody.useGravity = false;
	}
	
	void OnTriggerEnter( Collider c )
	{
		if( c.tag == "Player" && Dragon.dragonActive == false )
		{
			Dragon.dragon.Init();
		}
	}
}
