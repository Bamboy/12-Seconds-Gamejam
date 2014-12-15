using UnityEngine;
using System.Collections;

namespace asfgsadf{
	public class SplashScreen : MonoBehaviour {
		private void Start(){
			Invoke("TriggerNextScene", 2f);
		}
		private void TriggerNextScene(){
			Application.LoadLevel(1);
		}
	}
}