﻿using UnityEngine;
using System.Collections;

public class Timer : BaseTimer 
{
	private Timer time;
	public float timeEnd;
	public Texture2D bg_normal;
	public Texture2D bg_warning;
	public Texture2D bg_death;
	private Texture2D bg;
	public int blinkCount = 4;
	public float blinkLength = 0.25f;
	public float warningThreshold = 20.0f;
	private bool damageBlinking = false;

	private void Start()
	{
		Init(timeEnd);
		bg = bg_normal;

		StartCoroutine("Blink_TimeLow");
	}
	private void OnGUI()
	{
		GUI.DrawTexture( new Rect(Screen.width - 150, Screen.height - 105f, 150, 125), (Main.playerAlive ? bg : bg_death) );
		GUIStyle guiStyle = new GUIStyle();
		guiStyle.alignment = TextAnchor.MiddleCenter;
		guiStyle.fontSize = 50;
		GUI.Label(new Rect(Screen.width - 100f, Screen.height - 75f, 50, 50), ((int)current).ToString(), guiStyle);
	}

	protected override void OnTimeAdded( float addition )
	{
		base.OnTimeAdded( addition );
	}
	protected override void OnTimeRemoved( float subtraction )
	{
		base.OnTimeRemoved( subtraction );
		Debug.Log("TimeRemoved");

		if( Main.playerAlive )
			StartCoroutine("Blink_TimeReduced");
	}

	private IEnumerator Blink_TimeReduced()
	{
		damageBlinking = true;
		bg = bg_warning;
		for( int i = 0; i < blinkCount; i++ )
		{
			yield return new WaitForSeconds( blinkLength );
			bg = bg_normal;
			yield return new WaitForSeconds( blinkLength );
			bg = bg_warning;
		}
		yield return new WaitForSeconds( blinkLength );
		bg = bg_normal;
		damageBlinking = false;
	}
	private IEnumerator Blink_TimeLow()
	{
		if( BaseTimer.instance.current > warningThreshold )
		{
			if((bg == bg_warning && damageBlinking == false) || (bg == bg_death && Main.playerAlive == true)) //This is here so the gui doesnt get stuck on red after we go above the threshold.
				bg = bg_normal;

			yield return null;
		}
		else
		{
			//This division will cause the blinking to be faster as time gets lower, to a minimum of 0.05sec @ anything below 1.25 seconds left.
			float blinkTime = (BaseTimer.instance.current <= 1.25f ? 0.05f : (BaseTimer.instance.current / warningThreshold) );

			if( blinkTime <= 0.30f )
			{
				if( bg == bg_warning )
					bg = bg_death;
				else if( bg == bg_death )
					bg = bg_normal;
				else
					bg = bg_warning;
			}
			else
			{
				if( bg == bg_warning || (bg == bg_death && Main.playerAlive == true) )
					bg = bg_normal;
				else
					bg = bg_warning;
			}



			yield return new WaitForSeconds( blinkTime );
		}

		StartCoroutine("Blink_TimeLow");
	}















}