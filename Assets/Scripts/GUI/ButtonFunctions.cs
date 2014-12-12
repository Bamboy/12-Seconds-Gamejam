using UnityEngine;
using System.Collections;

namespace UI{
	public class ButtonFunctions : MonoBehaviour {
		private bool creditsEnable;
		private bool optionsEnable;
		public GameObject credits;
		public GameObject options;

		public void Exit(){
			Application.Quit();
		}
		public void GoToNewLevel(int LevelID){
			Application.LoadLevel(LevelID);
		}
		public void Options(){
			optionsEnable = !optionsEnable;
			creditsEnable = false;
			credits.SetActive(false);
			options.SetActive(optionsEnable);
		}
		public void Credits(){
			creditsEnable = !creditsEnable;
			optionsEnable = false;
			options.SetActive(false);
			credits.SetActive(creditsEnable);
		}
	}
}