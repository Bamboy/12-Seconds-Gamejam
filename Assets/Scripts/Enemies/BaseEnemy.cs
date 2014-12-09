using UnityEngine;
using Utils.Audio;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public abstract class BaseEnemy : MonoBehaviour
	{
		public float movementSpeed;
		protected float timeBonus;
		protected float timePenalty;
		protected int health;

		public static GameObject splatPrefab;
		public static GameObject textPrefab;

		protected virtual void Awake()
		{
			gameObject.AddComponent<Distancedeleter>();
		}

		protected virtual void Update()
		{
			transform.Translate(movementSpeed * Time.deltaTime, 0, 0, Space.World);
		}

		protected virtual void OnTriggerEnter(Collider col)
		{
			if( col.tag == "Player" )
			{
				OnHitPlayer();
			}
		}
		protected virtual void OnHitPlayer()
		{
			BaseTimer.instance.TimeModifier -= timePenalty;
			Destroy( this.gameObject );
		}

		public virtual void OnTakeDamage( int value )
		{
			health -= value;
			if( health <= 0 )
				Kill ();
		}

		public void Kill()
		{
			OnKilled ();
			Destroy( this.gameObject );
		}

		protected virtual void OnKilled()
		{ //Quickly do stuff before you die!
			BaseTimer.instance.TimeModifier += timeBonus;

			CreateSplatter();
			CreateText( "+"+VectorExtras.RoundTo(timeBonus, 0.1f)+" Sec", Color.green );

			if (Random.value < 0.3f)// 30%
				SoundEffectsPlayer.PlayRandomKill();
		}




		protected void CreateSplatter()
		{
			if( splatPrefab == null )
				splatPrefab = Resources.Load("Prefabs/Effects/RainBowSplatter") as GameObject;

			GameObject splat = (GameObject)Instantiate(splatPrefab, transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
			splat.transform.Rotate(0,0,Random.Range(-360.0f,360.0f));
			RaycastHit data;
			if( Physics.Raycast(splat.transform.position, Vector3.down, out data ) )
			{
				splat.transform.position = data.point;
			}
		}
		protected void CreateText( string text, Color color )
		{
			if( textPrefab == null )
				textPrefab = Resources.Load("Prefabs/Effects/Text") as GameObject;

			TextDisplay texMesh = ((GameObject)Instantiate(textPrefab, transform.position, textPrefab.transform.rotation)).GetComponent<TextDisplay>();
			if( texMesh != null )
			{
				texMesh.Display( text, color );
			}
			else
				Debug.LogWarning("This script was given a bad baseText prefab! (Needs a TextMesh component)", this);
		}









	}
}