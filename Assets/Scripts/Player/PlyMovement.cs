using UnityEngine;
using System.Collections;

public class PlyMovement : MonoBehaviour {
	public int laneCount = 4;
	public float laneWidth = 2.5f;
	public float speed = 1.0f;
	private int laneNumber;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			if(laneNumber < laneCount - 1){
				laneNumber++;
			}
		} else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			if(laneNumber > 0){
				laneNumber--;
			}
		}
		Vector3 t = transform.position;
		t.z = laneNumber * laneWidth;
		transform.position = t;

		transform.Translate( -1 * speed * Time.deltaTime, 0, 0, Space.World );
	}


}
