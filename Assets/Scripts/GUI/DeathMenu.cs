using UnityEngine;
using Utils.Audio;

public class DeathMenu : MonoBehaviour {
	private float timer = 1.042f;

	private void Start(){
		timer = 1.042f;
	}
	private void Update(){
		if(!Main.playerAlive){
			timer -= Time.deltaTime;
			if(timer <= 0f){
				Time.timeScale = 0.0f;
				MusicPlayer.Paused = true;
			}
		}
	}
	private void OnGUI(){
		if(!Main.playerAlive){
			if(timer <= 0){
				GUI.BeginGroup(new Rect((Screen.width/2) - 75, (Screen.height/2) - 59, 150, 118));
				GUI.Box(new Rect(0, 0, 150, 118), "You have lost.");
				if(GUI.Button(new Rect(0, 18, 150, 50), "Restart")){
					Application.LoadLevel(Application.loadedLevel);
				}
				if(GUI.Button(new Rect(0, 68, 150, 50), "Quit")){
					Application.LoadLevel(0);
				}
				GUI.EndGroup();
			}
		}
	}
}
