using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class SpeedPickup : PickupBehaviour
	{
		public float speedValue = 1.1f;
		public bool isMultiplier = true;

		protected override void OnPickup()
		{
			if( isMultiplier )
			{
				PlyMovement.Speed = (PlyMovement.Speed * speedValue);
			}
			else
			{ //Otherwise we treat speedValue as an additive.
				PlyMovement.Speed += speedValue;
			}
		}
	}
}