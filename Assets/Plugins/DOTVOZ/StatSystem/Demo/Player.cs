using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Stats.Demo
{
	public class Player : Unit
	{
		private void Awake()
		{
			Init("Units/Player");

			health.OnChangeCurrent = delegate(Stat stat) {
				print(stat);
			};// Create an event printing the health stat every time it's changed.

			DealFireDamage();
			Invoke("Heal", 10);
		}

		private void DealFireDamage()
		{
			Damage(-60, DamageType.Fire, new string[] { "Fire" });//Deal 60 Fire damage and apply "Fire" damage type effect.
		}

		private void Heal()
		{
			Damage(10, DamageType.Heal, new string[] { "Heal" });// Heal for 10 and apply "Heal" damage type effect.
		}
	}
}