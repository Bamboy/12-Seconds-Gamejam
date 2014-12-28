using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Plant : BaseEnemy
	{
		public float lane;
		public float fireTimePenalty = 0.65f;
		protected override void Awake ()
		{
			base.Awake ();
			enemyType = "plant";
			health = 3;
			timePenalty = 5.0f;
			timeBonus = Random.Range(5.10f,6.9f);
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