using UnityEngine;
using Utils;

namespace Enemies
{
	public class Rock : BaseEnemy 
	{
		public float timePenalty = 5.0f;
		public Vector2 speedRange;

		private bool hasPassed;
		private bool hasDeducted;

		public int health = 3;

		private void Start() 
		{
			movementSpeed = Random.Range( speedRange.x, speedRange.y );
		}
		public void Hit(){
			health--;
		}
		protected override void Update()
		{
			base.Update();
			if(health == 0){
				BaseTimer.instance.TimeModifier += 2;
				Die (this.collider, "+2 Seconds");
			}
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