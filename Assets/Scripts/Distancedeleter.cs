using UnityEngine;

public class Distancedeleter : MonoBehaviour {
	void Update () {
		if(this.transform.position.x > Main.player.transform.position.x + 75.0f){
			Destroy(gameObject);
		}
	}
}
