using UnityEngine;
using Utils.Audio;
using UnityEngine.UI;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static Transform player;

	public static MusicPlayer musicPlayer;
	public static SoundEffectsPlayer soundEffectsPlayer;

	public static bool playerAlive = true;

	[Range(0.0f, 1.0f)]
	public float masterVolume = 1.0f;
	[Range(0.0f,1.0f)]
	public float musicVolume = 0.8f;
	[Range(0.0f,1.0f)]
	public float effectVolume = 0.6f;
	[Range(0.0f,1.0f)]
	public float voiceVolume = 0.15f;

	private void Awake()
	{
		if(PlayerPrefs.HasKey("masterVolume")){
			UI.SliderFunctions.instance.volumeSliders[0].value = PlayerPrefs.GetFloat("masterVolume");
			UI.SliderFunctions.instance.volumeSliders[1].value = PlayerPrefs.GetFloat("musicVolume");
			UI.SliderFunctions.instance.volumeSliders[2].value = PlayerPrefs.GetFloat("effectVolume");
			UI.SliderFunctions.instance.volumeSliders[3].value = PlayerPrefs.GetFloat("voiceVolume");
		}
		AudioHelper.MasterVolume = UI.SliderFunctions.instance._masterVolume;
		AudioHelper.MusicVolume = UI.SliderFunctions.instance._musicVolume;
		AudioHelper.EffectVolume = UI.SliderFunctions.instance._effectVolume;
		AudioHelper.VoiceVolume = UI.SliderFunctions.instance._voiceVolume;

		if(Application.loadedLevel == 2){
			player = GameObject.FindGameObjectWithTag("Player").transform;
			musicPlayer = gameObject.AddComponent<MusicPlayer>();
			soundEffectsPlayer = gameObject.AddComponent<SoundEffectsPlayer>();
		}
	}

	public static bool OnWin()
	{
		if(Enemies.Dragon.dragon.Health <= 0){
			return true;
		} else {
			return false;
		}
	}
	private void OnDisable(){
		PlayerPrefs.SetFloat("masterVolume", AudioHelper.MasterVolume);
		PlayerPrefs.SetFloat("musicVolume", AudioHelper.MusicVolume);
		PlayerPrefs.SetFloat("effectVolume", AudioHelper.EffectVolume);
		PlayerPrefs.SetFloat("voiceVolume", AudioHelper.VoiceVolume);
	}
	private void OnApplicationQuit(){
		PlayerPrefs.SetFloat("masterVolume", AudioHelper.MasterVolume);
		PlayerPrefs.SetFloat("musicVolume", AudioHelper.MusicVolume);
		PlayerPrefs.SetFloat("effectVolume", AudioHelper.EffectVolume);
		PlayerPrefs.SetFloat("voiceVolume", AudioHelper.VoiceVolume);
	}
}