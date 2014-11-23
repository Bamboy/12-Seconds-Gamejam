using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public GameObject lanes;
	private GameObject[] lane;
	private Rigidbody character;
	private Camera mainCam;
	private bool jumped;
	private float distToGround;
	private int laneNumber;
	private Vector3 charPos;
	private Timer timer;
	private PlayerUnit pu;

	private void Awake(){
		character = GetComponent<Rigidbody>();
		lane = GameObject.FindGameObjectsWithTag("Lanes");
		timer = gameObject.AddComponent<Timer>();
		pu = GetComponent<PlayerUnit>();
		mainCam = Camera.main;
		timer.Init(10);
	}
	private void Start(){
		distToGround = GetComponentInChildren<BoxCollider>().bounds.extents.y;
	}
	private void Update(){
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			if(laneNumber < lane.Length){
				laneNumber++;
			}
		} else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			if(laneNumber > 0){
				laneNumber--;
			}
		}
		charPos = this.transform.position;
		charPos.z = lane[laneNumber].transform.position.z;
		this.transform.position = charPos;
	}
	private void FixedUpdate(){
		Vector3 trololol = character.velocity;
		trololol.x = -(pu.movementSpeed);
		character.velocity = trololol;
	}
}