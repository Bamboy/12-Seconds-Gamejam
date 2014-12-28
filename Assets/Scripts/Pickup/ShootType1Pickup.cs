using UnityEngine;
using System.Collections;

namespace Excelsion.Pickups
{
	public class ShootType1Pickup : PickupBehaviour 
	{
		public float duration = 7.5f;
		protected override void OnPickup()
		{
			Shooting.Instance.ShootMode( 1, duration );

			GameObject tex = CreateText( "Double Shot!!", textColor );
			tex.transform.parent = Main.player;
			tex.transform.localPosition = new Vector3(-5, 6, 0);
		}
	}
}