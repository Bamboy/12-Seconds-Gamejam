using UnityEngine;
using System.Collections.Generic;

//By Cristian "vozochris" Vozoca
namespace Utils.Audio
{
	public abstract class BaseAudioPlayer : MonoBehaviour
	{
		protected Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
		protected string playing = null;
		private bool paused = false;

		protected float volume;

		/// <summary>
		/// Play an Audio Source by id.
		/// </summary>
		/// <param name="id">Id.</param>
		public void Play(string id)
		{
			playing = id;
			audioSources[playing].Play();
		}

		/// <summary>
		/// Add an Audio Source with specified id.
		/// </summary>
		/// <param name="id">Id.</param>
		/// <param name="path">Path.</param>
		protected void Add(string id, string path)
		{
			Add(id, Resources.Load<AudioClip>("Audio/" + path + id));
		}

		/// <summary>
		/// Add an Audio Source with specified id.
		/// </summary>
		/// <param name="id">Id.</param>
		/// <param name="clip">Clip.</param>
		protected void Add(string id, AudioClip clip)
		{
			if (audioSources.ContainsKey(id))
			{
				Debug.LogWarning(string.Format("Song: {0} already exists!", id));
				return;
			}
			audioSources[id] = AudioHelper.CreateAudioSource(transform, clip, volume);
		}

		/// <summary>
		/// Removes an Audio Source with specified id.
		/// </summary>
		/// <param name="id">Id.</param>
		protected void Remove(string id)
		{
			audioSources.Remove(id);
		}

		/// <summary>
		/// Removes every Audio Sources.
		/// </summary>
		/// <param name="id">Id.</param>
		protected void Clear()
		{
			audioSources.Clear();
		}

		/// <summary>
		/// If the player is paused.
		/// </summary>
		/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
		public bool Paused
		{
			get { return paused; }
			set {
				paused = value;
				if (playing != null)
				{
					if (paused)
						audioSources[playing].Pause();
					else
						audioSources[playing].Play();
				}
			}
		}
	}
}