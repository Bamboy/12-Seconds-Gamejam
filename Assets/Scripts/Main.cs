using UnityEngine;
using Utils.Audio;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static Transform player;

	public static MusicPlayer musicPlayer;
	public static SoundEffectsPlayer soundEffectsPlayer;

	public static bool playerAlive = true;
	
	[Range(0.0f,1.0f)]
	public float musicVolume = 0.8f;
	[Range(0.0f,1.0f)]
	public float effectVolume = 0.6f;
	[Range(0.0f,1.0f)]
	public float voiceVolume = 0.15f;

	private void Awake()
	{
		AudioHelper.MusicVolume = musicVolume;
		AudioHelper.EffectVolume = effectVolume;
		AudioHelper.VoiceVolume = voiceVolume;
		musicPlayer = gameObject.AddComponent<MusicPlayer>();
		soundEffectsPlayer = gameObject.AddComponent<SoundEffectsPlayer>();

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public static bool OnWin()
	{
		if(Enemies.Dragon.dragon.Health <= 0){
			return true;
		} else {
			return false;
		}
	}
}