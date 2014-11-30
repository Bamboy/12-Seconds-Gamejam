using UnityEngine;
using System.Collections;

namespace Enemies
{
	public class Wave : BaseEnemy
	{
		public float timePenalty = 5.0f;
		public float texSpeed = 0.2f;
		private bool hasPassed;
		private bool hasDeducted;
		private float xOffset;

		private void Start()
		{
			renderer.material.mainTextureScale = new Vector2( 0.5f, 0.5f );
			xOffset = Random.value;
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
	}
}