using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Plant : BaseEnemy
	{
		public float lane;
		public float fireTimePenalty = 1.0f;
		protected override void Awake ()
		{
			base.Awake ();
			health = 4;
			timePenalty = 7.0f;
			timeBonus = 5.0f;
		}
		
		protected override void Update ()
		{
			lane = VectorExtras.RoundTo(transform.position.z, PlyMovement.laneWidth) / PlyMovement.laneWidth;
			if(lane == PlyMovement.laneNumber && Vector3.Distance(transform.position, Main.player.position) < 7.5f)
				DoFireDamage();

			base.Update();
		}

		void DoFireDamage()
		{
			BaseTimer.instance.TimeModifier -= fireTimePenalty;
		}



	}
}