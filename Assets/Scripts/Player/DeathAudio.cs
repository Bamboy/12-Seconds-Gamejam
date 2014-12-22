using UnityEngine;
using Utils.Audio;

namespace Player{
	public class DeathAudio : MonoBehaviour {
		public AudioClip deathAudio;
		private bool hasPlayed;
		private void Update(){
			if(!Main.PlayerAlive && !hasPlayed){
				AudioHelper.PlayClipAtPoint(deathAudio, Vector3.zero, AudioHelper.EffectVolume);
				hasPlayed = true;
			}
		}
	}
}