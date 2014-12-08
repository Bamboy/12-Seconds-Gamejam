using UnityEngine;
using Utils.Audio;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static Transform player;

	public static MusicPlayer musicPlayer;
	public static SoundEffectsPlayer soundEffectsPlayer;

	public static bool playerAlive = true;

	private void Awake()
	{
		AudioHelper.MusicVolume = 0.1f;
		AudioHelper.EffectVolume = 0.5f;
		AudioHelper.VoiceVolume = 1f;
		musicPlayer = gameObject.AddComponent<MusicPlayer>();
		soundEffectsPlayer = gameObject.AddComponent<SoundEffectsPlayer>();

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public static bool OnWin()
	{
		if(Enemies.Dragon.dragon.health <= 0){
			return true;
		} else {
			return false;
		}
	}
}