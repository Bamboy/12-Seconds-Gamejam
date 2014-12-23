using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class ShootType2Pickup : PickupBehaviour 
	{
		public float duration = 5.0f;
		protected override void OnPickup()
		{
			Shooting.Instance.ShootMode( 2, duration );
		}
	}
}