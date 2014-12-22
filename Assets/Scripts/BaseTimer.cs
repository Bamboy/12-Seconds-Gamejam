using UnityEngine;

//By Cristian "vozochris" Vozoca
public abstract class BaseTimer : MonoBehaviour
{
	public static BaseTimer instance;
	private float start;
	private float _time;
	private float timeModifier;
	public float current;
	private float timePerSecond = 1;
	private float timePerSecondModifier = 0;

	public void Init(float time)
	{
		instance = this;
		start = Time.timeSinceLevelLoad;
		this._time = start + time;
		timeModifier = 0;
	}

	private void Update()
	{
		if (Main.PlayerAlive)
		{
			float prevCurrent = current - timePerSecondModifier;
			current = _time - Time.timeSinceLevelLoad - start + timeModifier;
			timePerSecondModifier -= (prevCurrent - current) * (timePerSecond - 1);
			current += timePerSecondModifier;
		}

		if (current < 0)
		{
			//We died.
			Main.PlayerAlive = false;
			OnEnd(true);
		} 
		else
		{
			Main.PlayerAlive = true;
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

	public float TimePerSecond
	{
		get { return timePerSecond; }
		set { timePerSecond = value; }
	}

	protected abstract void OnTimeAdded( float addition );
	protected abstract void OnTimeRemoved( float subtraction );

	public virtual void OnAreaChange(int area)
	{
		if (area == 1)
			TimePerSecond = 2;
		else
			TimePerSecond = 1;
	}






















}