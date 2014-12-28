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

			GameObject tex = CreateText( "TRIPLE SHOT!!!", textColor );
			tex.transform.parent = Main.player;
			tex.transform.localPosition = new Vector3(-5, 6, 0);
		}



	}
}