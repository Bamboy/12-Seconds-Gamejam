using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour {
	void Update () {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Crab")){
			if(Vector3.Distance(transform.position, go.transform.position) < 2.0f){
				BaseTimer.instance.TimeModifier -= 10;
				Destroy(go);
			}
		}
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Starfish")){
			if(Vector3.Distance(transform.position, go.transform.position) < 2.0f){
				BaseTimer.instance.TimeModifier -= 10;
				Destroy(go);
			}
		}
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Plant")){
			if(Vector3.Distance(transform.position, go.transform.position) < 2.0f){
				BaseTimer.instance.TimeModifier -= 10;
				Destroy(go);
			}
		}
	}
}
