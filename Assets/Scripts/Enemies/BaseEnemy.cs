using UnityEngine;
using Utils.Audio;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public abstract class BaseEnemy : MonoBehaviour
	{
		public float movementSpeed;
		protected Color textColor = Color.green;

		protected virtual void Awake()
		{
			gameObject.AddComponent<Distancedeleter>();
		}

		protected virtual void Update()
		{
			transform.Translate(movementSpeed * Time.deltaTime, 0, 0, Space.World);
		}

		public virtual void Die(Collider col, string text)
		{
			WorldSpaceSpawns.SplatterText.instance.CreateSplatter(col);
			WorldSpaceSpawns.SplatterText.instance.CreateText(col, text, textColor);
			Destroy(gameObject);
			if (Random.value < 0.3f)// 30%
				SoundEffectsPlayer.PlayRandomKill();
		}
		public virtual void Die()
		{
			Destroy(gameObject);
			if (Random.value < 0.3f)// 30%
				SoundEffectsPlayer.PlayRandomKill();
		}

		public virtual void OnHitPlayer(){}

		protected virtual void OnTriggerEnter(Collider col)
		{
			if( col.tag == "Player" )
			{
				OnHitPlayer();
			}

		}
	}
}