using UnityEngine;
using Utils.Audio;
using UnityEngine.UI;
using Enemies;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static Main instance;

	public static Transform player;

	public static MusicPlayer musicPlayer;
	public static SoundEffectsPlayer soundEffectsPlayer;

	private bool playerAlive = true;

	private void Awake()
	{
		instance = this;

		Time.timeScale = 1.0f;
		if(Application.loadedLevel == 1 || Application.loadedLevel == 2){
			if(PlayerPrefs.HasKey("firstStart")){
				UI.SliderFunctions.instance.volumeSliders[0].value = PlayerPrefs.GetFloat("masterVolume");
				UI.SliderFunctions.instance.volumeSliders[1].value = PlayerPrefs.GetFloat("musicVolume");
				UI.SliderFunctions.instance.volumeSliders[2].value = PlayerPrefs.GetFloat("effectVolume");
				UI.SliderFunctions.instance.volumeSliders[3].value = PlayerPrefs.GetFloat("voiceVolume");
			} else {
				AudioHelper.MasterVolume = 1f;
				AudioHelper.MusicVolume = 1f;
				AudioHelper.EffectVolume = 1f;
				AudioHelper.VoiceVolume = 1f;
			}
			AudioHelper.MasterVolume = UI.SliderFunctions.instance._masterVolume;
			AudioHelper.MusicVolume = UI.SliderFunctions.instance._musicVolume;
			AudioHelper.EffectVolume = UI.SliderFunctions.instance._effectVolume;
			AudioHelper.VoiceVolume = UI.SliderFunctions.instance._voiceVolume;
		}
		if(Application.loadedLevel == 3){
			player = GameObject.FindGameObjectWithTag("Player").transform;
			musicPlayer = gameObject.AddComponent<MusicPlayer>();
			//soundEffectsPlayer = gameObject.AddComponent<SoundEffectsPlayer>();
		}
	}

	public static bool OnWin()
	{
		if (Dragon.dragon == null)
			return false;
		if (Dragon.dragon.Health > 0)
			return false;

		return true;
	}
	private void OnDisable(){
		PlayerPrefs.SetFloat("masterVolume", AudioHelper.MasterVolume);
		PlayerPrefs.SetFloat("musicVolume", AudioHelper.MusicVolume);
		PlayerPrefs.SetFloat("effectVolume", AudioHelper.EffectVolume);
		PlayerPrefs.SetFloat("voiceVolume", AudioHelper.VoiceVolume);
		PlayerPrefs.SetString("firstStart", "false");
	}
	private void OnApplicationQuit(){
		PlayerPrefs.SetFloat("masterVolume", AudioHelper.MasterVolume);
		PlayerPrefs.SetFloat("musicVolume", AudioHelper.MusicVolume);
		PlayerPrefs.SetFloat("effectVolume", AudioHelper.EffectVolume);
		PlayerPrefs.SetFloat("voiceVolume", AudioHelper.VoiceVolume);
		PlayerPrefs.SetString("firstStart", "false");
	}

	public static void GoToMainMenu()
	{
		if(Application.isMobilePlatform)
			Application.LoadLevel(2);
		else
			Application.LoadLevel(1);
	}

	public static bool PlayerAlive
	{
		get { return instance.playerAlive; }
		set { instance.playerAlive = value; }
	}
	public static bool GamePaused
	{
		get { return Time.timeScale == 0.0f; }
	}
	public static void PauseGame()
	{
		Time.timeScale = 0.0f;
		MusicPlayer.Paused = true;
	}
	public static void ResumeGame()
	{
		Time.timeScale = 1.0f;
		MusicPlayer.Paused = false;
	}
}