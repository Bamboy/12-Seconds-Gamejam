using UnityEngine;
using Utils.Audio;
using UnityEngine.UI;

namespace UI{
	public class SliderFunctions : MonoBehaviour 
	{
		public static SliderFunctions instance;
		public Slider[] volumeSliders;
		public Text[] volumeDisplays;

		private void Awake(){
			instance = this;
		}

		public void GetNewMasterVol()
		{
			AudioHelper.MasterVolume = volumeSliders[0].value;
			volumeDisplays[0].text = Mathf.RoundToInt( AudioHelper.MasterVolume * 100.0f ).ToString();
		}
		public void GetNewEffectVol()
		{
			AudioHelper.EffectVolume = volumeSliders[1].value;
			volumeDisplays[1].text = Mathf.RoundToInt( AudioHelper.EffectVolume * 100.0f ).ToString();
		}
		public void GetNewMusicVol()
		{
			AudioHelper.MusicVolume = volumeSliders[2].value;
			volumeDisplays[2].text = Mathf.RoundToInt( AudioHelper.MusicVolume * 100.0f ).ToString();
		}
		public void GetNewVoiceVol()
		{
			AudioHelper.VoiceVolume = volumeSliders[3].value;
			volumeDisplays[3].text = Mathf.RoundToInt( AudioHelper.VoiceVolume * 100.0f ).ToString();
		}
	}
}