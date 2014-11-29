using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundeffects : MonoBehaviour {
	public Dictionary<AudioClip, int> playRandomClip = new Dictionary<AudioClip, int>();
	public AudioClip[] audioClips;

	void Start(){
		for(int i = 0; i < audioClips.Length; i++){
			playRandomClip.Add(audioClips[i], i);
		}
		Debug.Log(playRandomClip.Count);
	}
}