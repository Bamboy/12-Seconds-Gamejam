using UnityEngine;

namespace Enemies
{
	public class Rock : BaseEnemy 
	{
		public float timePenalty = 5.0f;
		public Vector2 speedRange;

		private bool hasPassed;
		private bool hasDeducted;
		private void Start() 
		{
			movementSpeed = Random.Range( speedRange.x, speedRange.y );
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
		}
	}
}