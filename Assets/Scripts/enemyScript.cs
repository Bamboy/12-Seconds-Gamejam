using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	private float crabProjCount = 0;
	private float plantProjCount = 0;
	private float dragonProjCount = 0;

	void OnTriggerEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			if(this.gameObject.tag == "Starfish"){
				BaseTimer.instance.current -= 1;
			}
			if(this.gameObject.tag == "Crab"){
				BaseTimer.instance.current -= 2;
			}
			if(this.gameObject.tag == "Plant"){
				BaseTimer.instance.current -= 4;
			}
			if(this.gameObject.tag == "Dragon"){
				BaseTimer.instance.current -= 6;
			}
		}
		if(col.gameObject.tag == "Projectile"){
			if(this.gameObject.tag == "Starfish"){
				BaseTimer.instance.current += 2;
			}
			if(this.gameObject.tag == "Crab"){
				crabProjCount++;
				if(crabProjCount == 2){
					BaseTimer.instance.current += 3;
				}
			}
			if(this.gameObject.tag == "Plant"){
				plantProjCount++;
				if(plantProjCount == 3){
					BaseTimer.instance.current += 5;
				}
			}
			if(this.gameObject.tag == "Dragon"){
			}
		}
	}
}