using UnityEngine;
using System.Collections;

namespace Excelsion.Gooey
{
	public class SplashScreen : MonoBehaviour 
	{
		public Texture2D SplashBackground;
		public float splashTime = 3.0f;
		public Gradient gradient;
		private Texture2D fade;
		
		private void Start()
		{
			fade = new Texture2D(1,1);
			Invoke("TriggerNextScene", splashTime);
		}
		
		private void OnGUI()
		{	
			//We need to make sure that the logo draws FIRST so that the fade effect will draw over it. This is why we don't attach a Fade.cs,
			//because you cant guarentee which will render first.
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), SplashBackground, ScaleMode.ScaleToFit);
			SetFade( Time.timeSinceLevelLoad / splashTime );
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade, ScaleMode.StretchToFill);
		}
		
		private void SetFade( float t )
		{
			fade.SetPixel(0,0, gradient.Evaluate( t ));
			fade.Apply();
		}
		private void TriggerNextScene()
		{
			Application.LoadLevel(1);
		}
	}
}