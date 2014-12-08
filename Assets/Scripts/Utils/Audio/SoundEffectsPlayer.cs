using UnityEngine;
using System;

//By Cristian "vozochris" Vozoca
namespace Utils.Audio
{
	public enum KillSoundEffects
	{
		BOOOYYY, SplitYa, Yep
	}
	public class SoundEffectsPlayer : BaseAudioPlayer
	{
		public static SoundEffectsPlayer instance;
		private static BaseAudioPlayer baseInstance;

		private static Array killSounds;

		private void Awake()
		{
			instance = this;
			baseInstance = this as BaseAudioPlayer;

			volume = AudioHelper.VoiceVolume;

			killSounds = Enum.GetValues(typeof(KillSoundEffects));
			foreach(object killSound in killSounds)
			{
				Add(killSound.ToString(), "Sound Effects/Kill/");
			}
		}

		public static void PlayRandomKill()
		{
			instance.Play(killSounds.GetValue(UnityEngine.Random.Range(0, killSounds.Length)).ToString());
		}

		/// <summary>
		/// If the music player is paused.
		/// </summary>
		/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
		public new static bool Paused
		{
			get { return baseInstance.Paused; }
			set { baseInstance.Paused = value; }
		}
	}
}