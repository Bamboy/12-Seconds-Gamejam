using UnityEngine;
using System.Collections;

public class Distancedeleter : MonoBehaviour {
	void Update () {
		if(this.transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x + 50.0f){
			Destroy(gameObject);
		}
	}
}
