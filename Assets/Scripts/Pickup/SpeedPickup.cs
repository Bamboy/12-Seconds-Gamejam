using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class SpeedPickup : PickupBehaviour
	{
		public float speedValue = 1.1f;
		public bool isMultiplier = true;

		public static int pickupCount = 0;
		public int[] requiredForNextArea;


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

			CheckCount();
		}

		//Area progression.
		void CheckCount()
		{
			GameObject tex = null;
			if( Infinitetile.Area != 3 )
			{
				pickupCount++;
				if( requiredForNextArea[ Infinitetile.Area ] <= pickupCount )
				{
					Debug.Log("Next area! "+ pickupCount);
					Infinitetile.NextArea ();
					pickupCount = 0;
					tex = CreateText( "Next area!", textColor );
				}
			}
			if( tex == null )
				tex = CreateText( "Speed up!", textColor );

			tex.transform.parent = Main.player;
			tex.transform.localPosition = new Vector3(-2, 7, 0);
		}

	}
}