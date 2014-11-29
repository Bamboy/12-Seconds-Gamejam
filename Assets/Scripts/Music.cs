using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioSource[] audioSources;
	public  float timer;
	private float timerr;
	public float _timer;
	public float _timerr;
	private bool _boolOne = true;
	private bool _boolTwo;

	void Start(){
		audioSources[0].Play();
		timer = audioSources[0].clip.length;
		timerr = audioSources[1].clip.length;
		_timer = timer;
		_timerr = timerr;
	}
	void Update () {
		if(_boolOne){
			_timer -= Time.deltaTime;
			if(_timer <= 0){
				if(audioSources[0].isPlaying){
					audioSources[0].Stop();
				}
				audioSources[1].Play();
				_timer = timer;
				_boolTwo = true;
				_boolOne = false;
			}
		}
		if(_boolTwo){
			_timerr -= Time.deltaTime;
			if(_timerr <= 0){
				if(audioSources[1].isPlaying){
					audioSources[1].Stop();
				}
				audioSources[0].Play();
				_timerr = timerr;
				_boolOne = true;
				_boolTwo = false;
			}
		}
	}
}
