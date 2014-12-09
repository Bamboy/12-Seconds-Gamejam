using UnityEngine;

namespace Enemies
{
	public class Quicksand : RotatingEnemy 
	{
		public float speedMultiplier = 0.2f;

		protected override void Awake()
		{
			base.Awake ();
			collider.isTrigger = true;
			rigidbody.useGravity = false;
			health = int.MaxValue; //We dont want this to be killable.
			timePenalty = 0.0f;
			timeBonus = 0.0f;
		}

		protected override void OnTriggerEnter( Collider c )
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