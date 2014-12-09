using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture background;
	public Texture boxes;
	public Texture mainScreenTexture;
	public Texture play;
	public Texture credits;
	public Texture quit;
	float Width = 800;
	float Height = 480;
	Vector3 Scale;
	bool creditToggle;

	void OnGUI(){
		Scale.x = Screen.width/Width;
		Scale.y = Screen.height/Height;
		Scale.z = 1;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Scale);
		GUI.DrawTexture(new Rect(0, 0, Width, Height), background);
		GUI.DrawTexture(new Rect((Width/2) - 125, (Height/2)- 175, 250, 350), boxes);
		GUI.DrawTexture(new Rect((Width/2) - 100, (Height/2) - 145, 200, 70), mainScreenTexture);
		if(Application.isLoadingLevel)
			GUI.Label(new Rect(0, 0, 100, 50), "Loading...");
		Play();
		Credit();
		Quit();
	}
	void Play(){
		if(GUI.Button(new Rect((Width/2) - 88, (Height/2) - 30, 170, 30), "", GUIStyle.none)){
			Application.LoadLevel(2);
		}
		GUI.DrawTexture(new Rect((Width/2) - 50, (Height/2) - 22.5f, 100, 20), play);
	}
	void Credit(){
		if(GUI.Button(new Rect((Width/2) - 88, (Height/2) + 57.5f, 170, 30), "", GUIStyle.none)){
			creditToggle = !creditToggle;
		}
		GUI.DrawTexture(new Rect((Width/2) - 60, (Height/2) + 54, 120, 20), credits);
		if(creditToggle){
			GUI.Label(new Rect(150, 0, 200, 100), "Justin Bruystens");
			GUI.Label(new Rect(150, 50, 200, 100), "Nick Evans");
			GUI.Label(new Rect(150, 100, 200, 100), "Stephan Ennen");
			GUI.Label(new Rect(150, 150, 200, 100), "Bjorn Hensvold");
			GUI.Label(new Rect(150, 200, 200, 100), "William Patten");
			GUI.Label(new Rect(150, 250, 200, 100), "Nick Bierenbroodspot");
			GUI.Label(new Rect(150, 300, 200, 100), "Tristan Gray");
			GUI.Label(new Rect(150, 350, 200, 100), "Cristian Vozoca");
			GUI.Label(new Rect(150, 400, 200, 100), "Sebastian Ujhazi");
		}
	}
	void Quit(){
		if(GUI.Button(new Rect((Width/2) - 88, (Height/2) + 145, 170, 30), "", GUIStyle.none)){
			Application.Quit();
		}
		GUI.DrawTexture(new Rect((Width/2) - 60, (Height/2) + 135, 120, 20), quit);
	}
}
