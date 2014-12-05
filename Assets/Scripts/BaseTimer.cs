﻿using UnityEngine;

//By Cristian "vozochris" Vozoca
public abstract class BaseTimer : MonoBehaviour
{
	public static BaseTimer instance;
	private float start;
	private float _time;
	private float timeModifier;
	public float current;

	public void Init(float time)
	{
		instance = this;
		start = Time.time;
		this._time = start + time;
		timeModifier = 0;
	}

	private void Update()
	{
		current = _time - Time.time - start + timeModifier;

		if (current < 0)
		{
			//We died.
			Main.playerAlive = false;
			OnEnd(true);
		} 
		else
		{
			Main.playerAlive = true;
			OnEnd(false);
		}
	}

	/// <summary>
	/// Called when the Timer ends.
	/// </summary>
	protected bool OnEnd(bool set){
		return set;
	}

	/// <summary>
	/// Gets or sets the time modifier.
	/// </summary>
	/// <value>The time modifier.</value>
	public float TimeModifier
	{
		get { return timeModifier; }
		set { 
			if( value > timeModifier )
				OnTimeAdded( value - timeModifier );
			else if( value < timeModifier )
				OnTimeRemoved( value - timeModifier );

			timeModifier = value; 
		}
	}

	protected virtual void OnTimeAdded( float addition )
	{

	}
	protected virtual void OnTimeRemoved( float subtraction )
	{

	}






















}