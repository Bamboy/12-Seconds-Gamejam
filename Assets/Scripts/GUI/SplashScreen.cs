using UnityEngine;
using System.Collections;

namespace asfgsadf{
	public class SplashScreen : MonoBehaviour 
	{
		public float changeTime = 5.0f;
		private void Start(){
			Invoke("TriggerNextScene", changeTime);
		}
		private void TriggerNextScene(){
			Application.LoadLevel(1);
		}
	}
}