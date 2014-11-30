using UnityEngine;
using System.Collections;

public class DeathSplatter : MonoBehaviour 
{
	public GameObject splatter;
	bool isQuitting = false;

	void OnApplicationQuit()
	{
		isQuitting = true;
	}
	void OnDestroy()
	{
		if( !isQuitting )
		{
			Instantiate(splatter, transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
		}
	}
}
