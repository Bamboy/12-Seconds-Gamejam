using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour 
{
	public GameObject prefab;
	void OnDestroy()
	{
		Instantiate( prefab );
		Time.timeScale = 0.0f;
	}
}
