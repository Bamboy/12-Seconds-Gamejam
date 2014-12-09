using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	private bool _continue;
	public Texture win;
	public GUISkin skin;
	public Texture[] textures;
	float Width = 800;
	float Height = 480;
	Vector3 Scale;
	private void Update()
	{
		if(Main.OnWin() && !_continue)
		{
			Time.timeScale = 0.0f;
		} 
		else if(_continue)
		{
			Time.timeScale = 1.0f;
		}
	}
	private void OnGUI()
	{
		Scale.x = Screen.width/Width;
		Scale.y = Screen.height/Height;
		Scale.z = 1;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Scale);
		if(Main.OnWin() && !_continue)
		{
				GUI.DrawTexture(new Rect(0, 0, Width, Height), win);
				GUI.skin = skin;
			if(GUI.Button(new Rect((Width/2) - 100, (Height/2) + 50, 200, 60), ""))
				{
					_continue = true;
				}
			GUI.DrawTexture(new Rect((Width/2) - 52.5f, (Height/2) + 65f, 95, 25), textures[0]);
			if(GUI.Button(new Rect((Width/2) - 100, (Height/2) + 110, 200, 60), ""))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
			GUI.DrawTexture(new Rect((Width/2) - 52.5f, (Height/2) + 127.5f, 95, 20), textures[1]);
			if(GUI.Button(new Rect((Width/2) - 100, (Height/2) + 170, 200, 60), ""))
				{
					Application.LoadLevel(0);
				}
			GUI.DrawTexture(new Rect((Width/2) - 42.5f, (Height/2) + 187.5f, 80, 20), textures[2]);
		}
	}
}
