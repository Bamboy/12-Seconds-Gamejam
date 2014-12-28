using UnityEngine;
using System.Collections;
using Utils.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Excelsion.Pickups;

namespace Excelsion.UI
{
	public class ButtonFunctions : MonoBehaviour 
	{
		public static ButtonFunctions instance;
		private int activeMenu = -1;
		public GameObject mainGroup;
		public GameObject optionsGroup;
		//public GameObject hiScoreGroup;
		public GameObject creditsGroup;

		private bool _paused;
		private bool _continue;
		public GameObject pauseButton;
		public GameObject pauseMenu;
		public GameObject winMenu;
		public GameObject loseMenu;
		private bool forcedWin = false;

		private void Awake()
		{
			instance = this;
			if ( SceneIsMenu )
			{
				mainGroup.SetActive   ( true );
				optionsGroup.SetActive(false);
				//hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
			}
		}
		void OnLevelLoaded( int lvl )
		{
			instance = this;
			if( lvl != 1 && lvl != 2 )
				activeMenu = -1; //-1 is a null menu.
			else
				activeMenu = 0; //Zero is just your basic menu.
		}
		bool SceneIsMenu
		{
			get{ return ( Application.loadedLevel != 3 ); }
		}
		bool MenuIsOpen
		{
			get{
				return ( SceneIsMenu || winMenu.activeInHierarchy || loseMenu.activeInHierarchy || pauseMenu.activeInHierarchy );
			}
		}
		public void ForceWinDisplay()
		{
			forcedWin = true;
			pauseButton.SetActive(false);
			loseMenu.SetActive(false);
			pauseMenu.SetActive(false);
			winMenu.SetActive(true);
			Main.PauseGame();
		}
		private void Update()
		{
			if( !SceneIsMenu )
			{
				if( MenuIsOpen )
				{
					pauseButton.SetActive( false );
					Timer.Display = false;
				}
				else
				{
					pauseButton.SetActive( true );
					Timer.Display = true;
				}

				if( forcedWin ) //We're forcing ourselves to win. Ignore everything else.
					return;

				if(!Main.PlayerAlive) //Player died.
				{
					loseMenu.SetActive(true);
					Main.PauseGame ();
				} 
				else //Player has not died.
				{
					if(Main.OnWin() && _continue == false) //We just won the game. Display win screen
					{
						winMenu.SetActive(true);
						Main.PauseGame ();
					} 
					else if(Main.OnWin() && _continue == true) //User chose to continue playing after winning
					{
						winMenu.SetActive(false);
						_paused = false;
						Main.ResumeGame ();
					}
					else
					{
						loseMenu.SetActive(false);
						if( _paused == true ) //Is the game paused?
						{
							pauseMenu.SetActive( true );
							Main.PauseGame ();
						}
						else
						{
							pauseMenu.SetActive( false );
							Main.ResumeGame ();
						}
					}
				}



			}
		}

		#region Random Button Events
		public void OnButton_Exit(){
			Application.Quit();
		}
		public void ReloadCurrentLevel()
		{
			SpeedPickup.pickupCount = 0;
			Application.LoadLevel(Application.loadedLevel);
		}
		public void Restart(){
			SpeedPickup.pickupCount = 0;
			Application.LoadLevel(Application.loadedLevel);
		}
		public void GoToNewLevel(int LevelID){
			SpeedPickup.pickupCount = 0;
			Application.LoadLevel(LevelID);
		}

		public void OnButton_OpenWebsite(string url){
			Application.OpenURL(url);
		}
		public void PauseButton()
		{
			Main.PauseGame();
			_paused = true;
			pauseMenu.SetActive(true);
		}
		public void Resume()
		{
			if(Main.OnWin())
				_continue = true;
			
			Main.ResumeGame();
			_paused = false;
			pauseMenu.SetActive(false);
		}
		public void Quit(){
			Main.GoToMainMenu();
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
				//hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
				break;
			case 1: //Options menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive( true );
				//hiScoreGroup.SetActive(false);
				creditsGroup.SetActive(false);
				break;
			/*case 2: //Highscore menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				hiScoreGroup.SetActive( true );
				creditsGroup.SetActive(false);
				break; */
			case 3: //Credits menu
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				//hiScoreGroup.SetActive(false);
				creditsGroup.SetActive( true );
				break;
			default:
				mainGroup.SetActive   (false);
				optionsGroup.SetActive(false);
				//hiScoreGroup.SetActive(false);
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
		/*
		public void OnButton_HiScore()
		{
			if( activeMenu == 2 )
				SwitchToMenu( 0 );
			else
				SwitchToMenu( 2 );
		} */
		public void OnButton_Credits()
		{
			if( activeMenu == 3 )
				SwitchToMenu( 0 );
			else
				SwitchToMenu( 3 );
		}


















	}
}