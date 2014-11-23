using UnityEngine;
using System.Collections;

public class Infinitetile : MonoBehaviour {
	public GameObject tile;
	public GameObject prefab;
	Vector3 position;
	private float timer = 0.75f;

	// Use this for initialization
	void Start () {
		position  = new Vector3(-9.86707f, -0.07385421f, 1.151482f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0){
			position.x -= (float)30;
			Instantiate(prefab, position, Quaternion.identity);
			timer = 0.75f;
		}
	}
}