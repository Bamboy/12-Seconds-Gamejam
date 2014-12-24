using UnityEngine;
using System.Collections;
using Utils.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Excelsion.UI
{
	public class ButtonFunctions : MonoBehaviour 
	{
		private int activeMenu = -1;
		public GameObject mainGroup;
		public GameObject optionsGroup;
		public GameObject hiScoreGroup;
		public GameObject creditsGroup;

		private bool _continue;
		public GameObject pauseMenu;
		public GameObject winMenu;
		public GameObject loseMenu;

		private void Awake()
		{
			//if (Application.loadedLevel == 1 || Application.loadedLevel == 2)
			//	enabled = false;
			mainGroup.SetActive   ( true );
			optionsGroup.SetActive(false);
			hiScoreGroup.SetActive(false);
			creditsGroup.SetActive(false);
		}
		void OnLevelLoaded( int lvl )
		{
			if( lvl != 1 && lvl != 2 )
				activeMenu = -1; //-1 is a null menu.
			else
				activeMenu = 0; //Zero is just your basic menu.
		}
		bool SceneIsMenu
		{
			get{ return ( Application.loadedLevel != 3 ); }
		}

		private void Update()
		{
			if( !SceneIsMenu )
			{
				if(Main.OnWin() && !_continue){
					winMenu.SetActive(true);
					Time.timeScale = 0f;
				} else if(Main.OnWin() && _continue){
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
			}
		}

		#region Random Button Events
		public void OnButton_Exit(){
			Application.Quit();
		}
		public void ReloadCurrentLevel(){
			Application.LoadLevel(Application.loadedLevel);
		}
		public void GoToNewLevel(int LevelID){
			Application.LoadLevel(LevelID);
		}

		public void OnButton_OpenWebsite(string url){
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
		#endregion


		//This is ONLY used on the main menu.
		private void SwitchToMenu( int newMenu )
		{
			switch( newMenu )
			{
			case 0: //Just our basic menu
				mainGroup.SetActive   ( true );
				optionsGroup.SetActive(false);
				hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
				break;
			case 1: //Options menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive( true );
				hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
				break;
			case 2: //Highscore menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				hiScoreGroup.SetActive( true );
				creditsGroup.SetActive(false);
				break;
			case 3: //Credits menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				hiScoreGroup.SetActive(false);
				creditsGroup.SetActive( true );
				break;
			default:
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
				Debug.LogError("MenuSwitching should only be done on scenes 1 or 2! Did you mess up the scene order in build settings?", this);
				return;
			}
			activeMenu = newMenu;
		}

		public void OnButton_Options()
		{
			if( activeMenu == 1 )
				SwitchToMenu( 0 );
			else
				SwitchToMenu( 1 );
		}
		public void OnButton_HiScore()
		{
			if( activeMenu == 2 )
				SwitchToMenu( 0 );
			else
				SwitchToMenu( 2 );
		}
		public void OnButton_Credits()
		{
			if( activeMenu == 3 )
				SwitchToMenu( 0 );
			else
				SwitchToMenu( 3 );
		}


















	}
}