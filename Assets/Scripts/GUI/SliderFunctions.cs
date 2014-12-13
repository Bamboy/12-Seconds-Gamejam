using UnityEngine;
using Utils.Audio;
using UnityEngine.UI;

namespace UI{
	public class SliderFunctions : MonoBehaviour {
		public static SliderFunctions instance;
		public Slider[] volumeSliders;

		private void Awake(){
			instance = this;
		}

		public float _masterVolume{
			get{return AudioHelper.MasterVolume;}
			set{ AudioHelper.MasterVolume = value;}
		}
		public float _musicVolume{
			get{return AudioHelper.MusicVolume;}
			set{ AudioHelper.MusicVolume = value;}
		}
		public float _effectVolume{
			get{return AudioHelper.EffectVolume;}
			set{ AudioHelper.EffectVolume = value;}
		}
		public float _voiceVolume{
			get{return AudioHelper.VoiceVolume;}
			set{ AudioHelper.VoiceVolume = value;}
		}
	}
}