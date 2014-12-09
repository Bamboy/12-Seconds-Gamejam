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
	float counter = 100;
	Vector3 Scale;
	bool creditToggle;

	void Update(){
		counter -= Time.deltaTime * 10;
		if(!creditToggle && counter <= -160)
			counter = 100;
	}
	void OnGUI(){
		Scale.x = Screen.width/Width;
		Scale.y = Screen.height/Height;
		Scale.z = 1;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Scale);
		GUI.DrawTexture(new Rect(0, 0, Width, Height), background);
		GUI.DrawTexture(new Rect((Width/2) - 125, (Height/2)- 175, 250, 350), boxes);
		if(!creditToggle)
			GUI.DrawTexture(new Rect((Width/2) - 100, (Height/2) - 145, 200, 70), mainScreenTexture);
		if(Application.isLoadingLevel)
			GUI.Label(new Rect(0, 0, 100, 50), "Loading...");
		Play();
		Credit();
		Quit();
		if(GUI.Button(new Rect(0, Height - 100, 100, 100), "Excelsion"))
			Application.OpenURL("www.excelsion.org");
	}
	void Play(){
		if(GUI.Button(new Rect((Width/2) - 121, (Height/2) - 35, 238, 44), "", GUIStyle.none)){
			Application.LoadLevel(2);
		}
		GUI.DrawTexture(new Rect((Width/2) - 50, (Height/2) - 22.5f, 100, 20), play);
	}
	void Credit(){
		if(GUI.Button(new Rect((Width/2) - 121, (Height/2) + 43, 238, 44), "", GUIStyle.none)){
			creditToggle = !creditToggle;
		}
		GUI.DrawTexture(new Rect((Width/2) - 60, (Height/2) + 54, 120, 20), credits);
		if(creditToggle){
			if(counter > -160){
				GUI.BeginGroup(new Rect((Width/2) - 109, (Height/2) - 154f, 211.5f, 91));
				GUI.Label(new Rect(0, 0 + counter, 200, 100), "Justin Bruystens");
				GUI.Label(new Rect(0, 20 + counter, 200, 100), "Nick Evans");
				GUI.Label(new Rect(0, 40 + counter, 200, 100), "Stephan Ennen");
				GUI.Label(new Rect(0, 60 + counter, 200, 100), "Bjorn Hensvold");
				GUI.Label(new Rect(0, 80 + counter, 200, 100), "William Patten");
				GUI.Label(new Rect(0, 100 + counter, 200, 100), "Nick Bierenbroodspot");
				GUI.Label(new Rect(0, 120 + counter, 200, 100), "Tristan Gray");
				GUI.Label(new Rect(0, 140 + counter, 200, 100), "Cristian Vozoca");
				GUI.Label(new Rect(0, 160 + counter, 200, 100), "Sebastian Ujhazi");
				GUI.EndGroup();
			} else {
				creditToggle = false;
			}
		}
	}
	void Quit(){
		if(GUI.Button(new Rect((Width/2) - 121, (Height/2) + 122, 238, 44), "", GUIStyle.none)){
			Application.Quit();
		}
		GUI.DrawTexture(new Rect((Width/2) - 60, (Height/2) + 135, 120, 20), quit);
	}
}
