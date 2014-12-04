using UnityEngine;
using System.Collections;

namespace Enemies
{
	public class BreatheFire : MonoBehaviour 
	{
		public ParticleSystem ps;
		private bool isBreathingFire = false;

		public void FireStart()
		{
			isBreathingFire = true;
			ps.Play();
		}
		public void FireEnd()
		{
			isBreathingFire = false;
			ps.Stop();
		}

		public bool IsBreathingFire()
		{
			return isBreathingFire;
		}

		void Update () 
		{
			
		}
	}
}