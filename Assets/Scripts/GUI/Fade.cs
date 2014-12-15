using UnityEngine;
using System.Collections;

namespace Excelsion.Gooey
{
	public class Fade : MonoBehaviour 
	{
		public float time = 3.0f;
		public Gradient gradient;
		private Texture2D fade;
		
		private void Start()
		{
			fade = new Texture2D(1,1);
		}
		
		private void OnGUI()
		{	
			SetFade( Time.timeSinceLevelLoad / time );
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade, ScaleMode.StretchToFill);
		}
		
		private void SetFade( float t )
		{
			fade.SetPixel(0,0, gradient.Evaluate( t ));
			fade.Apply();
		}
	}
}
