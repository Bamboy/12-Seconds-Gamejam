using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Fish : BaseEnemy
	{
		protected override void Awake ()
		{
			base.Awake ();
			health = 3;
			timePenalty = 4.0f;
			timeBonus = 3.0f;
		}
		
		protected override void Update ()
		{
			base.Update ();
		}








	}
}