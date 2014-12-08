using UnityEngine;
using Utils.Audio;

public class PauseMenu : MonoBehaviour {
	private bool isPaused;
	private bool pauseAll;
	private bool temporarybool;
	private void Update (){
		if(isPaused){
			Time.timeScale = 0.0f;
			MusicPlayer.Paused = true;
			temporarybool = false;
		} else if(!temporarybool && !isPaused){
			Time.timeScale = 1.0f;
			MusicPlayer.Paused = false;
			temporarybool = true;
		}
	}
	private void OnGUI(){
		if(!isPaused){
			if(GUI.Button(new Rect(Screen.width - 50, 0, 50, 50), "")){
				isPaused = true;
			}
		}
		if(isPaused){
			GUI.BeginGroup(new Rect((Screen.width/2) - 75, (Screen.height/2) - 59, 150, 118));
			GUI.Box(new Rect(0, 0, 150, 118), "Paused");
			if(GUI.Button(new Rect(0, 18, 150, 50), "Continue")){
				isPaused = false;
			}
			if(GUI.Button(new Rect(0, 68, 150, 50), "Quit")){
				Application.LoadLevel(1);
			}
			GUI.EndGroup();
		}
	}
	private void OnApplicationPause(bool pauseStatus){
		isPaused = pauseStatus;
	}
}
