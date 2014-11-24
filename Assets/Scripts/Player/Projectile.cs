using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 3.0f;

	void Start()
	{
		rigidbody.AddForce( direction * speed, ForceMode.Impulse );
	}

	//// Update is called once per frame
	//void Update () 
	//{
	//	transform.Translate( direction * speed * Time.deltaTime );
	//}

	private float crabProjCount = 0;
	private float plantProjCount = 0;
	private float dragonProjCount = 0;
	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collision");
		if(col.gameObject.tag == "Player"){
			if(this.tag == "Starfish"){
				BaseTimer.instance.current -= 1;
				Destroy( this.gameObject );
			}
			else if(this.tag == "Crab"){
				BaseTimer.instance.current -= 2;
				Destroy( this.gameObject );
			}
			else if(this.tag == "Plant"){
				BaseTimer.instance.current -= 4;
				Destroy( this.gameObject );
			}
			else if(this.tag == "Dragon"){
				BaseTimer.instance.current -= 6;
				Destroy( this.gameObject );
			}
		}
		else if(col.gameObject.tag == "Projectile"){
			if(this.tag == "Starfish"){
				BaseTimer.instance.current += 2;
				Destroy( col.gameObject );
				Destroy( this.gameObject );
			}
			else if(this.tag == "Crab"){
				crabProjCount++;
				if(crabProjCount == 2){
					BaseTimer.instance.current += 3;
					Destroy( col.gameObject );
					Destroy( this.gameObject );
				}
			}
			else if(this.tag == "Plant"){
				plantProjCount++;
				if(plantProjCount == 3){
					BaseTimer.instance.current += 5;
					Destroy( col.gameObject );
					Destroy( this.gameObject );
				}
			}
			else if(this.tag == "Dragon"){
				
			}
		}
	}

}
