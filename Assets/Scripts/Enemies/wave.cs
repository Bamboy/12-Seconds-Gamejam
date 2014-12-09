using UnityEngine;
using Utils;

namespace Enemies
{
	public class Wave : BaseEnemy
	{
		public float speedPenalty = 1.0f;
		public float texSpeed = 0.2f;
		private bool hasPassed;
		private bool hasDeducted;
		private float xOffset;

		protected override void Awake()
		{
			base.Awake();
			renderer.material.mainTextureScale = new Vector2( 0.5f, 0.5f );
			xOffset = Random.value;
			health = int.MaxValue; //We don't want to be killable.
			timePenalty = 2.5f;
		}

		protected override void Update()
		{
			base.Update();
			if(Vector3.Distance(transform.position, Main.player.position) < 2.0f && !hasDeducted)
			{
				hasPassed = true;
			}
			if(hasPassed && !hasDeducted){
				BaseTimer.instance.TimeModifier -= timePenalty;
				hasDeducted = true;
			}
			
			Vector2 offset = renderer.material.mainTextureOffset;
			offset.y -= (texSpeed * Time.deltaTime);
			renderer.material.mainTextureOffset = new Vector2(xOffset, offset.y);
		}

		public override void OnTakeDamage( int value )
		{
			return; //Don't do anything.
		}
		protected override void OnHitPlayer()
		{
			//Slow the player AND take time away.
			BaseTimer.instance.TimeModifier -= timePenalty;
			PlyMovement.Speed -= speedPenalty;
		}

























	}
}