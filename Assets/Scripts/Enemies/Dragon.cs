using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Dragon : BaseEnemy
	{
		public int health;

		protected override void Awake()
		{
			base.Awake();
			Infinitetile.area = 4;
			Debug.LogWarning("Remove this Awake after finishing.");
		}

		protected override void Update()
		{
			movementSpeed = -PlyMovement.speed;
			base.Update();
		}

		public void Hit()
		{
			health--;
			if (health == 0)
			{
				Destroy(gameObject);
				Main.OnWin();
			}
		}
	}
}