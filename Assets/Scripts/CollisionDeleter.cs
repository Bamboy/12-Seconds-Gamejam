using UnityEngine;
using System.Collections;

public class CollisionDeleter : MonoBehaviour {
	void OnCollisionEnter(Collision collision){
		Destroy(collision.gameObject);
	}
}
