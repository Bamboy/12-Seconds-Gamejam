using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public abstract class BaseEnemy : MonoBehaviour
	{
		public float movementSpeed;

		protected virtual void Awake()
		{
			gameObject.AddComponent<Distancedeleter>();
		}

		protected virtual void Update()
		{
			transform.Translate(movementSpeed * Time.deltaTime, 0, 0, Space.World);
		}
	}
}