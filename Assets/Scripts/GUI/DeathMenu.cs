using UnityEngine;
using Utils.Audio;

public class DeathMenu : MonoBehaviour {
	private float timer = 1.042f;
	public GUISkin skin;
	public Texture lose;
	public Texture[] textures;
	float Width = 800;
	float Height = 480;
	Vector3 Scale;
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
		Scale.x = Screen.width/Width;
		Scale.y = Screen.height/Height;
		Scale.z = 1;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Scale);
		GUI.skin = skin;
		if(!Main.playerAlive){
			if(timer <= 0){
				GUI.DrawTexture(new Rect(0, 0, Width, Height), lose);
				if(GUI.Button(new Rect((Width/2) - 120, (Height/2) + 70, 240, 65), "")){
					Application.LoadLevel(Application.loadedLevel);
				}
				GUI.DrawTexture(new Rect((Width/2) - 60, (Height/2) + 85f, 110, 30), textures[0]);
				if(GUI.Button(new Rect((Width/2) - 120, (Height/2) + 135, 240, 65), "")){
					Application.LoadLevel(0);
				}
				GUI.DrawTexture(new Rect((Width/2) - 40, (Height/2) + 150, 80, 30), textures[1]);
			}
		}
	}
}
