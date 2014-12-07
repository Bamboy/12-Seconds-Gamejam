using UnityEngine;
using System.Collections.Generic;

//By Cristian "vozochris" Vozoca
public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer instance;

	private Dictionary<string, AudioSource> songs = new Dictionary<string, AudioSource>();
	private string playing = null;

	private string[] loopedSongs;
	private int loopPlayIndex = 0;

	private bool paused = false;

	private void Awake()
	{
		instance = this;

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
					if (!songs[playing].isPlaying)
						Play(loopedSongs[++loopPlayIndex % loopedSongs.Length]);
				}
			}
		}
	}

	private void Play(string id)
	{
		playing = id;
		songs[playing].Play();
	}

	private void PlayLooped(params string[] ids)
	{
		loopPlayIndex = 0;
		loopedSongs = ids;
		Play(loopedSongs[0]);
	}

	private void Add(string id, string path = null)
	{
		Add(id, Resources.Load<AudioClip>("Audio/" + path + id));
	}

	private void Add(string id, AudioClip clip)
	{
		if (songs.ContainsKey(id))
		{
			Debug.LogWarning(string.Format("Song: {0} already exists!", id));
			return;
		}
		songs[id] = AudioHelper.CreateAudioSource(transform, clip, AudioHelper.MusicVolume);
	}

	private void Remove(string id)
	{
		songs.Remove(id);
	}

	/// <summary>
	/// If the music player is paused.
	/// </summary>
	/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
	public static bool Paused
	{
		get { return instance.paused; }
		set {
			instance.paused = value;
			if (instance.playing != null)
			{
				if (instance.paused)
					instance.songs[instance.playing].Pause();
				else
					instance.songs[instance.playing].Play();
			}
		}
	}
}