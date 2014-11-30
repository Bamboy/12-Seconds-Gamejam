using UnityEngine;

namespace Enemies
{
	public class Quicksand : RotatingEnemy 
	{
		public float speedMultiplier = 0.2f;

		void Awake () 
		{
			collider.isTrigger = true;
			rigidbody.useGravity = false;
		}

		void OnTriggerEnter( Collider c )
		{
			if( c.tag == "Player" )
			{
				PlyMovement.speedMultiplier = speedMultiplier;
			}
		}

		void OnTriggerExit( Collider c )
		{
			if( c.tag == "Player" )
			{
				PlyMovement.speedMultiplier = 1.0f;
			}
		}
	}
}