using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioClip music;
	public AudioClip musicc;
	private float timer;
	private float timerr;
	private float _timer;
	private float _timerr;

	void Start(){
		AudioSource.PlayClipAtPoint(music, Vector3.zero);
	}
	void Update () {
		
	}
}
