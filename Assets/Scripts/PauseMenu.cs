using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool isPaused;
	private void Update (){
		if(isPaused){
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}
	private void OnGUI(){
		if(!isPaused){
			if(GUI.Button(new Rect(Screen.width - 50, 0, 50, 50), "")){
				isPaused = true;
			}
		}
		if(isPaused){
			GUI.BeginGroup(new Rect((Screen.width/2) - 75, (Screen.height/2) - 150, 150, 300));
			GUI.Box(new Rect(0, 0, 150, 300), "Paused");
			if(GUI.Button(new Rect(0, 15, 150, 100), "Continue")){
				isPaused = false;
			}
			if(GUI.Button(new Rect(0, 115, 150, 100), "Quit")){
				Application.LoadLevel(0);
			}
			GUI.EndGroup();
		}
	}
}
