using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {
	public int counter;
	public static EnemyDestroy instance;

	void Start(){
		instance = this;
	}
	void Update () {
		if(counter == 3 && this.tag == "Crab"){
			Destroy(gameObject);
			BaseTimer.instance.TimeModifier += 2;
		}
		if(counter == 2 && this.tag == "Plant"){
			Destroy(gameObject);
			BaseTimer.instance.TimeModifier += 2;
		}
		if(counter == 4 && this.tag == "Rock"){
			Destroy(gameObject);
			BaseTimer.instance.TimeModifier += 2;
		}
		if(counter == 4 && this.tag == "Starfish"){
			Destroy(gameObject);
			BaseTimer.instance.TimeModifier += 2;
		}
	}
}
