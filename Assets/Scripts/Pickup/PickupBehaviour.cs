using UnityEngine;
using System.Collections;
using Utils.Audio;

namespace Excelsion.Pickups
{
	[RequireComponent( typeof(Rigidbody), typeof(BoxCollider), typeof(Distancedeleter) )]
	public abstract class PickupBehaviour : MonoBehaviour 
	{
		public AudioClip pickupAudioOne;
		public AudioClip pickupAudioTwo;
		public Color textColor;
		private static GameObject textPrefab;

		protected virtual void Start()
		{
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			BoxCollider box = collider as BoxCollider;
			box.center = new Vector3(0.0f, 10.0f, 0.0f);
			box.size =   new Vector3(0.6f,  2.5f, 0.6f);
			box.isTrigger = true;
		}

		void OnTriggerEnter( Collider col )
		{
			if( col.tag == "Player" )
			{
				if(Random.Range(0f, 1f) < 0.5f)
					AudioHelper.PlayClipAtPoint(pickupAudioOne, Vector3.zero, AudioHelper.EffectVolume);
				else
					AudioHelper.PlayClipAtPoint(pickupAudioTwo, Vector3.zero, AudioHelper.EffectVolume);
				OnPickup();
				Destroy( this.gameObject );
			}
		}

		protected abstract void OnPickup();

		protected GameObject CreateText( string text, Color color )
		{
			if( textPrefab == null )
				textPrefab = Resources.Load("Prefabs/Effects/Text") as GameObject;
			
			TextDisplay texMesh = ((GameObject)Instantiate(textPrefab, transform.position, textPrefab.transform.rotation)).GetComponent<TextDisplay>();
			if( texMesh != null )
			{
				texMesh.Display( text, color );
				return texMesh.gameObject;
			}
			else
			{
				Debug.LogWarning("This script was given a bad baseText prefab! (Needs a TextMesh component)", this);
				return null;
			}
		}
	}
}