using UnityEngine;

public class Distancedeleter : MonoBehaviour {
	void Update () {
		if(this.transform.position.x > Main.player.transform.position.x + 50.0f){
			Destroy(gameObject);
		}
	}
}
