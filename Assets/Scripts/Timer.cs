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
		GUI.DrawTexture(new Rect(Screen.width - 150, Screen.height - 105f, 150, 125), background);
		GUIStyle label = new GUIStyle();
		label.alignment = TextAnchor.MiddleCenter;
		label.fontSize = 50;
		GUI.Label(new Rect(Screen.width - 100f, Screen.height - 75f, 50, 50), ((int)time.current).ToString(), label);
	}
}
