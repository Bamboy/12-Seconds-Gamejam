using UnityEngine;
using System.Collections;

public class LanesMovement : MonoBehaviour {
	private Vector3 newPos;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update () {
		newPos = this.transform.position;
		newPos.x = player.transform.position.x;
		this.transform.position = newPos;
	}
}
