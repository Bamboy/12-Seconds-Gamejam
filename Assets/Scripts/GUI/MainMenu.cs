using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	bool creditToggle;
	float lol;

	void OnGUI(){
		Play();
		Credit();
		Quit();
		GUI.Label(new Rect(Screen.width/2, 10, 50, 50), Application.GetStreamProgressForLevel(1).ToString());
	}
	void Play(){
		if(GUI.Button(new Rect(0, 0, 100, 100), "Play")){
			Application.LoadLevel(1);
		}
	}
	void Credit(){
		if(GUI.Button(new Rect(0, 100, 100, 100), "Credits")){
			creditToggle = !creditToggle;
		}
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
		if(GUI.Button(new Rect(0, 200, 100, 100), "Quit")){
			Application.Quit();
		}
	}
}
