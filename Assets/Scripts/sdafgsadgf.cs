using UnityEngine;
using System.Collections;

public class sdafgsadgf : MonoBehaviour {
	void Update(){
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Crab")){
			if(Vector3.Distance(transform.position, go.transform.position) < 2.0f){
				BaseTimer.instance.TimeModifier -= 2;
				Destroy(go);
			}
		}
	}
	void OnTriggerEnter(Collider col){
		Debug.Log("hit");
		if(col.gameObject.tag == "Crab"){
			BaseTimer.instance.TimeModifier -= 2;
			Destroy(col.gameObject);
		}
	}
}
