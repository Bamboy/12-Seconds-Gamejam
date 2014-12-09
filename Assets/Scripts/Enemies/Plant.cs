using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Plant : BaseEnemy
	{
		public int health = 4;
		public float lane;
		public float fireTimePenalty = 1.0f;
		protected override void Awake ()
		{
			
		}
		
		protected override void Update ()
		{
			lane = VectorExtras.RoundTo(transform.position.z, PlyMovement.laneWidth) / PlyMovement.laneWidth;
			if(health == 0){
				BaseTimer.instance.TimeModifier += 5;
				Die (this.collider, "+5 Seconds");
			}
			if(lane == PlyMovement.laneNumber && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 7.5f)
				DoDamage();
		}
		public void DoDamage(){
			BaseTimer.instance.TimeModifier -= fireTimePenalty;
		}
		public void Hit(){
			health--;
		}
	}
}