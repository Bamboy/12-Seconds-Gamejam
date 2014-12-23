using UnityEngine;
using System.Collections;
using Utils.Audio;
public class AudioInitalizer : MonoBehaviour 
{
	private static bool initalized = false;

	[Range(0.0f,1.0f)]
	public float masterVol = 1.0f;
	[Range(0.0f,1.0f)]
	public float musicVol = 0.75f;
	[Range(0.0f,1.0f)]
	public float effectVol = 0.9f;
	[Range(0.0f,1.0f)]
	public float voiceVol = 1.0f;


	void Awake () 
	{
		if( !initalized ) //Only run once per application open
		{
			AudioHelper.MasterVolume = masterVol;
			AudioHelper.MusicVolume = musicVol;
			AudioHelper.EffectVolume = effectVol;
			AudioHelper.VoiceVolume = voiceVol;
			initalized = true;
		}
	}

}
