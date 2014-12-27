using UnityEngine;
using System.Collections;

namespace Excelsion.UI{
	public class SplashScreen : MonoBehaviour 
	{
		public float changeTime = 5.0f;
		private void Start(){
			Invoke("TriggerNextScene", changeTime);
		}
		private void TriggerNextScene(){
			if(Application.isMobilePlatform)
				Application.LoadLevel(2);
			else
				Application.LoadLevel(1);
		}
	}
}