using UnityEngine;
using System.Collections;
using Utils.Audio;

namespace Excelsion.UI{
	public class ButtonFunctions : MonoBehaviour {
		private bool creditsEnable;
		private bool optionsEnable;
		private bool _continue;
		private bool hasWon;
		private bool paused;
		public GameObject credits;
		public GameObject options;
		public GameObject pauseMenu;
		public GameObject winMenu;
		public GameObject loseMenu;

		private void Awake()
		{
			if (Application.loadedLevel == 1)
				enabled = false;
		}

		private void Update(){
			if(Main.OnWin())
				hasWon = true;
			if(hasWon && !_continue){
				winMenu.SetActive(true);
				Time.timeScale = 0f;
			} else if(hasWon && _continue){
				Time.timeScale = 1f;
				winMenu.SetActive(false);
			}
			if(!Main.PlayerAlive){
				loseMenu.SetActive(true);
				Time.timeScale = 0f;
			} else {
				loseMenu.SetActive(false);
				Time.timeScale = 1f;
			}
			if(paused){
				Time.timeScale = 0.0f;
			} else {
				Time.timeScale = 1.0f;
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
			paused = true;
		}
		public void Resume(){
			if(Main.OnWin())
				_continue = true;
			pauseMenu.SetActive(false);
			MusicPlayer.Paused = true;
			paused = false;
		}
		public void Restart(){
			Application.LoadLevel(Application.loadedLevel);
		}
		public void Quit(){
			Application.LoadLevel(1);
		}
	}
}