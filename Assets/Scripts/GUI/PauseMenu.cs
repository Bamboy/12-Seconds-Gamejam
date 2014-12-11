using UnityEngine;
using Utils.Audio;

public class PauseMenu : MonoBehaviour {
	public GUISkin skin;
	public GUISkin pauseButton;
	public Texture2D[] textures;
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
		if(Input.GetKeyDown(KeyCode.Escape))
			isPaused = true;
	}
	private void OnGUI(){
		if(!isPaused){
			GUI.skin = pauseButton;
			if(GUI.Button(new Rect(Screen.width - 50, 0, 50, 50), "")){
				isPaused = true;
			}
		}
		GUI.skin = skin;
		if(isPaused){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textures[3]);
			GUI.BeginGroup(new Rect((Screen.width/2) - 150, (Screen.height/2) - 150, 300, 300));
			GUI.Box(new Rect(0, 0, 300, 300), "Paused");
			if(GUI.Button(new Rect(50, 75, 200, 60), "")){
				isPaused = false;
			}
			GUI.DrawTexture(new Rect(92.5f, 87.5f, 105, 27.5f), textures[0]);//Resume
			if(GUI.Button(new Rect(50, 135, 200, 60), "")){
				Application.LoadLevel(Application.loadedLevel);
			}
			GUI.DrawTexture(new Rect(92.5f, 147.5f, 105, 27.5f), textures[1]);
			if(GUI.Button(new Rect(50, 195, 200, 60), "")){
				Application.LoadLevel(1);
			}
			GUI.DrawTexture(new Rect(92.5f, 207.5f, 105, 27.5f), textures[2]);
			GUI.EndGroup();
		}
	}
	private void OnApplicationPause(bool pauseStatus){
		isPaused = pauseStatus;
	}
}
