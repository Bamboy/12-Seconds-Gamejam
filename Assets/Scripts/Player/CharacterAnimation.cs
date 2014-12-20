using UnityEngine;
using Utils;

public class CharacterAnimation : CharacterInput {
	private Animator anim;
	private float speed;
	//private bool canCheck = false;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("IsDead", false);
	}
	void Update () {
		RaycastHit hit;
		if( Physics.Raycast( transform.position, Vector3.left, out hit ) )
		{
			if( hit.distance <= 1.1f ){
				anim.SetFloat("Speed", 0f);
			} else {
				anim.SetFloat("Speed", (PlyMovement.Speed * PlyMovement.speedMultiplier * Time.deltaTime) * 10);
			}
		}

		if(GetShootInput()){
			anim.SetBool("Fire", true);
			Invoke("SetAnimBoolFalse", 0.833f);
		}

		if(!Main.playerAlive)
			anim.SetBool("IsDead", true);

		if(PlyMovement.RightAnim){
			anim.SetFloat("Direction", 1.0f);
		} else if(PlyMovement.LeftAnim){
			anim.SetFloat("Direction", -1.0f);
		} else{
			anim.SetFloat("Direction", 0.0f);
		}
	}
	void SetAnimBoolFalse(){
		anim.SetBool("Fire", false);
	}
}
