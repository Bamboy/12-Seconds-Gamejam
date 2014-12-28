using UnityEngine;
using System.Collections;
using Enemies;

public class Cheatsies : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
		StartCoroutine(DoCheatsies());
	}

	public IEnumerator DoCheatsies()
	{
		yield return new WaitForSeconds(5.0f);
		Dragon.dragon.Health = 5;
		BaseTimer.instance.TimeModifier += 5000000.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
