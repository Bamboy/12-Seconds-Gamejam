using UnityEngine;
using System.Collections;

public class Timer : BaseTimer {
	private Timer time;
	public float timeEnd;
	public Texture2D background;

	private void Start(){
		time = this;
		time.Init(timeEnd);
	}
	private void OnGUI(){
		GUI.DrawTexture(new Rect(Screen.width - 100, Screen.height - 150f, 100, 150), background);
		GUI.Label(new Rect(Screen.width - 62.5f, Screen.height - 87.5f, 50, 50), ((int)time.current).ToString());
	}
}
