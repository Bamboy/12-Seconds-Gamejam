using UnityEngine;
using System.Collections;

public class DeathSplatter : MonoBehaviour {
	public GameObject splatter;
	void OnDestroy(){
		Vector3 position = transform.position;
		position.z += 0.5f;
		Instantiate(splatter, position, Quaternion.LookRotation(Vector3.up));
	}
}
