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
			health = 4;
			timePenalty = 7f;
			timeBonus = Random.Range(4.50f,5.75f);
		}



		protected override void Update ()
		{	
			transform.Translate(-2 * Time.deltaTime, 0, 0, Space.World);
		}

	}
}