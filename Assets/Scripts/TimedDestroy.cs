using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour 
{
	public float time = 1.0f;

	void Awake () 
	{
		DestroyObject( this.gameObject, time );
	}
}
