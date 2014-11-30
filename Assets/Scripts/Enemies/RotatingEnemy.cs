using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public abstract class RotatingEnemy : BaseEnemy
	{
		public Vector3 rotation;
		private bool randomRotation = false;

		protected override void Awake ()
		{
			base.Awake ();
			if (randomRotation)
				rotation = new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
		}

		protected override void Update()
		{
			base.Update();
			transform.Rotate(rotation * Time.deltaTime);
		}
	}
}