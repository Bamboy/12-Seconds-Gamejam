using UnityEngine;

//By Cristian "vozochris" Vozoca
public abstract class BaseTimer : MonoBehaviour
{
	private float start;
	private float time;
	private float timeModifier;

	public void Init(float time)
	{
		start = Time.time;
		this.time = start + time;
		timeModifier = 0;
	}

	private void Update()
	{
		float current = time - Time.time - start + timeModifier;

		if (current < 0)
			OnEnd();
	}

	/// <summary>
	/// Called when the Timer ends.
	/// </summary>
	protected abstract void OnEnd();

	/// <summary>
	/// Gets or sets the time modifier.
	/// </summary>
	/// <value>The time modifier.</value>
	public float TimeModifier
	{
		get { return timeModifier; }
		set { timeModifier = value; }
	}
}