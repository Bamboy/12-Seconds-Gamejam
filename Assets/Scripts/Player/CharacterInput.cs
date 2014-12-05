using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {
	
	//Android
	protected Vector2 firstPosition;
	protected Vector2 lastPosition;
	protected Ray sRay;

	protected int GetSwipe(){//used as a bool for multiple outputs
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				firstPosition = touch.position;
				lastPosition = touch.position;
			}
			if(touch.phase == TouchPhase.Moved){
				lastPosition = touch.position;
			}
			if(touch.phase == TouchPhase.Ended){
				if(firstPosition.x - lastPosition.x > 80){//swipe left
					return 0;//returned something
				} else if(firstPosition.x - lastPosition.x < -80){//swipe right
					return 1;//returned something
				} else if(firstPosition == lastPosition){//touch
					sRay = Camera.main.ScreenPointToRay(touch.position);
					return 2;//returned something
				}
			}
		}
		return 3;//returned nothing
	}
	protected bool GetRightInput(){
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || GetSwipe() == 1)
		{
			return true;
		} else{
			return false;
		}
	}
	protected bool GetLeftInput(){
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || GetSwipe() == 0)
		{
			return true;
		} else{
			return false;
		}
	}
	protected bool GetShootInput(){
		if(Input.GetMouseButtonDown(0) || GetSwipe() == 2){
			return true;
		} else {
			return false;
		}
	}
}