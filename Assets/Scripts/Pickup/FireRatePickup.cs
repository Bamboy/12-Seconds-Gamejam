using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class FireRatePickup : PickupBehaviour
	{
		public float delayAddition = -0.1f;
		
		protected override void OnPickup()
		{
			Shooting.Delay += delayAddition;
		}
	}
}