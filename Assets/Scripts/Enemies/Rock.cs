using UnityEngine;
using Utils;

namespace Enemies
{
	public class Rock : BaseEnemy 
	{
		public Vector2 speedRange;

		private bool hasPassed;
		private bool hasDeducted;

		protected override void Awake() 
		{
			base.Awake ();
			health = 5;
			timePenalty = 10.0f;
			timeBonus = 2.0f;
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

		//protected
	}
}