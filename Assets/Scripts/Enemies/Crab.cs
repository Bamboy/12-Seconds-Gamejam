using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Crab : BaseEnemy
	{
		protected override void Awake ()
		{
			base.Awake ();
			health = 3;
			timePenalty = 5.75f;
			timeBonus = 3.0f;
		}

		protected override void Update ()
		{
			base.Update ();
		}

	}
}