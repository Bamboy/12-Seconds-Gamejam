using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Crab : BaseEnemy
	{
		public int health = 3;
		protected override void Awake ()
		{

		}

		protected override void Update ()
		{
			if(health == 0){
				BaseTimer.instance.TimeModifier += 3;
				Die (this.collider, "+3 Seconds");
			}
		}
		public void Hit(){
			health--;
		}
	}
}