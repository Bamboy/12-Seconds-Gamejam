using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Utils.Audio
{
	public class MusicPlayer : BaseAudioPlayer
	{
		public static MusicPlayer instance;
		private static BaseAudioPlayer baseInstance;

		private string[] loopedSongs;
		private int loopPlayIndex = 0;

		private void Awake()
		{
			instance = this;
			baseInstance = this as BaseAudioPlayer;

			volume = AudioHelper.MusicVolume;

			Add("1", "Music/");
			Add("2", "Music/");
			Add("3", "Music/");

			PlayLooped("1", "2", "3");
		}

		private void Update()
		{
			if (!Paused)
			{
				if (loopedSongs != null)
				{
					if (playing != null)
					{
						if (!audioSources[playing].isPlaying)
							Play(loopedSongs[++loopPlayIndex % loopedSongs.Length]);
					}
				}
			}
		}

		private void PlayLooped(params string[] ids)
		{
			loopPlayIndex = 0;
			loopedSongs = ids;
			Play(loopedSongs[0]);
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