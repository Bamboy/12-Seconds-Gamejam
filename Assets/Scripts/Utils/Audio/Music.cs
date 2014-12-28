using UnityEngine;
using System.Collections;
using Utils.Audio;

public class Music : MonoBehaviour 
{
	public AudioClip song1;
	public AudioClip song2;
	public AudioClip song3;

	private AudioSource s1;
	private AudioSource s2;
	private AudioSource s3;

	private int playing;
	// Use this for initialization
	void Start () 
	{
		s1 = AudioHelper.CreateAudioSource( transform, song1 );
		s2 = AudioHelper.CreateAudioSource( transform, song2 );
		s3 = AudioHelper.CreateAudioSource( transform, song3 );

		StartCoroutine(ShuffleSongs());
	}

	IEnumerator ShuffleSongs()
	{
		playing = Random.Range(0, 3) + 1; //Gets us a range between 1 and 3.
		float length = Play( playing );

		yield return new WaitForSeconds( length );

		StartCoroutine( ShuffleSongs() );
	}

	float Play( int song )
	{
		Debug.Log( song );
		switch(song)
		{
		case 1:
			s1.Play();
			return s1.clip.length;
		case 2:
			s2.Play();
			return s2.clip.length;
		default:
			s3.Play();
			return s3.clip.length;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		s1.volume = AudioHelper.GetVolume( 0.5f, SoundType.Music );
		s2.volume = AudioHelper.GetVolume( 0.5f, SoundType.Music );
		s3.volume = AudioHelper.GetVolume( 0.5f, SoundType.Music );


	}
}
