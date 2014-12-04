using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {
	private Animator anim;
	private float speed;
	private bool canCheck = false;

	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update () {
		anim.SetFloat("Speed", (PlyMovement.speed * PlyMovement.speedMultiplier * Time.deltaTime) * 10);

		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("Fire", true);
			Invoke("SetAnimBoolFalse", 0.833f);
		}

		if(BaseTimer.instance.current < 0)
			anim.SetBool("IsDead", true);

		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			anim.SetFloat("Direction", 1.0f);
		} else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			anim.SetFloat("Direction", -1.0f);
		} else{
			anim.SetFloat("Direction", 0.0f);
		}
	}
	void SetAnimBoolFalse(){
		anim.SetBool("Fire", false);
	}
}
