using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Crab : BaseEnemy
	{
		protected override void Awake ()
		{
			base.Awake ();
			enemyType = "crab";
			health = 3;
			timePenalty = 5.75f;
			timeBonus = Random.Range(5.50f,6.75f);
		}



		protected override void Update ()
		{	
			transform.Translate(-2 * Time.deltaTime, 0, 0, Space.World);
		}

	}
}