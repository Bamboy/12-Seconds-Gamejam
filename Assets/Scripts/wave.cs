using UnityEngine;
using System.Collections;

public class wave : MonoBehaviour {
	public float speed = 5.0f;
	private bool hasPassed;
	private bool hasDeducted;
	void Update () {
		transform.Translate( 1 * speed * Time.deltaTime, 0, 0, Space.World );
		if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.0f && !hasDeducted){
			hasPassed = true;
		}
		if(hasPassed && !hasDeducted){
			BaseTimer.instance.TimeModifier -= 10;
			hasDeducted = true;
		}
	}
}
