using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	private bool _continue;
	private void Update()
	{
		if(Main.OnWin())
		{
			Time.timeScale = 0.0f;
		} 
		else if(Main.OnWin() && _continue)
		{
			Time.timeScale = 1.0f;
		}
	}
	private void OnGUI()
	{
		if(Main.OnWin())
		{
			GUI.BeginGroup(new Rect((Screen.width/2) - 75, (Screen.height/2) - 150, 150, 300));
				GUI.Box(new Rect(0, 0, 150, 300), "You Win!");

				if(GUI.Button(new Rect(0, 15, 150, 100), "Continue"))
				{
					_continue = true;
				}

				if(GUI.Button(new Rect(0, 115, 150, 100), "Main Menu"))
				{
					Application.LoadLevel(0);
				}
			GUI.EndGroup();
		}
	}
}
