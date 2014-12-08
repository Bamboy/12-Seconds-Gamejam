using UnityEngine;
using System.Collections;

namespace UI.Splash{
	public class SplashScreen : MonoBehaviour {
		public Texture2D SplashBackground;

		private void Start(){
			Invoke("TriggerNextScene", 2f);
		}
		private void OnGUI(){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), SplashBackground);
		}
		private void TriggerNextScene(){
			Application.LoadLevel(1);
		}
	}
}