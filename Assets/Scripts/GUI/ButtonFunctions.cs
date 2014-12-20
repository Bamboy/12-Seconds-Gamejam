using UnityEngine;
using System.Collections;
using Utils.Audio;

namespace Excelsion.UI{
	public class ButtonFunctions : MonoBehaviour {
		private bool creditsEnable;
		private bool optionsEnable;
		private bool _continue;
		public GameObject credits;
		public GameObject options;
		public GameObject pauseMenu;
		public GameObject winMenu;
		public GameObject loseMenu;

		private void Update(){
			if(Main.OnWin() && !_continue){
				winMenu.SetActive(true);
				Time.timeScale = 0f;
			} else if(Main.OnWin() && _continue){
				Time.timeScale = 1f;
				winMenu.SetActive(false);
			}
			if(!Main.playerAlive){
				loseMenu.SetActive(true);
				Time.timeScale = 0f;
			} else {
				loseMenu.SetActive(false);
				Time.timeScale = 1f;
			}
		}
		public void Exit(){
			Application.Quit();
		}
		public void ReloadCurrentLevel(){
			Application.LoadLevel(Application.loadedLevel);
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
		public void OpenWebsite(string url){
			Application.OpenURL(url);
		}
		public void PauseButton(){
			pauseMenu.SetActive(true);
			MusicPlayer.Paused = true;
			Time.timeScale = 0.0f;
		}
		public void Resume(){
			if(Main.OnWin())
				_continue = true;
			pauseMenu.SetActive(true);
			MusicPlayer.Paused = true;
			Time.timeScale = 1.0f;
		}
		public void Restart(){
			Application.LoadLevel(Application.loadedLevel);
		}
		public void Quit(){
			Application.LoadLevel(1);
		}
	}
}