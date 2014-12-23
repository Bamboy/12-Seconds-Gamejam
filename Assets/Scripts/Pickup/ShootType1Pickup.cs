using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class ShootType1Pickup : PickupBehaviour 
	{
		public float duration = 6.5f;
		protected override void OnPickup()
		{
			Shooting.Instance.ShootMode( 1, duration );
		}
	}
}