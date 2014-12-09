using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	[RequireComponent( typeof(Rigidbody), typeof(BoxCollider), typeof(Distancedeleter) )]
	public abstract class PickupBehaviour : MonoBehaviour 
	{
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
				OnPickup();
				Destroy( this.gameObject );
			}
		}

		protected abstract void OnPickup();
	}
}