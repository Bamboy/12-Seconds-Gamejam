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
			timeBonus = Random.Range(3.50f,4.50f);
		}
		
		protected override void Update ()
		{
			base.Update ();
		}
		public override void OnTakeDamage (int value)
		{
			base.OnTakeDamage (value);
		}







	}
}