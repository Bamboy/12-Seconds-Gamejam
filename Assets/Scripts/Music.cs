using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioClip music;
	public AudioClip musicc;
	private int playCount;
	public float timer;
	private float timerr;
	private float _timer;
	private float _timerr;
	private bool _boolOne;
	private bool _boolTwo;

	void Start(){
		AudioSource.PlayClipAtPoint(music, Vector3.zero);
		timer = music.length;
		timerr = musicc.length;
		_timer = timer;
		_timerr = timerr;
	}
	void Update () {
		while(_boolOne){
			_timer -= Time.deltaTime;
		}
		while(_boolTwo){
			_timerr -= Time.deltaTime;
		}
		if(_timer <= 0){
			AudioSource.PlayClipAtPoint(musicc, Vector3.zero);
		}
		if(_timerr <= 0){
			AudioSource.PlayClipAtPoint(music, Vector3.zero);
		}
	}
}
