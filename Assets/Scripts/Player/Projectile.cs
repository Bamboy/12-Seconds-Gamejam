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

	private static float crabProjCount = 0;
	private static float plantProjCount = 0;
	private static float starfishProjCount = 0;
	void OnTriggerEnter(Collider col)
	{
		Destroy( this.gameObject );
		if(col.gameObject.tag == "Crab"){
			crabProjCount++;
			if(crabProjCount == 2){
				BaseTimer.instance.TimeModifier += 3;
				crabProjCount = 0;
				Destroy( col.gameObject );
				Destroy( this.gameObject );
			}
			} else if(col.gameObject.tag == "Starfish"){
				BaseTimer.instance.TimeModifier += 2;
				starfishProjCount = 0;
				Destroy( col.gameObject );
				Destroy( this.gameObject );
			} else if(col.gameObject.tag == "Plant"){
				plantProjCount++;
				if(plantProjCount == 3){
					BaseTimer.instance.TimeModifier += 5;
				 	plantProjCount = 0;
					Destroy( col.gameObject );
					Destroy( this.gameObject );
			}
			else if(col.gameObject.tag == "Rock"){
				plantProjCount++;
				if(plantProjCount == 3){
					BaseTimer.instance.TimeModifier += 5;
					plantProjCount = 0;
					Destroy( col.gameObject );
					Destroy( this.gameObject );
				}
		}
			else if(col.gameObject.tag == "Dragon"){
				plantProjCount++;
				if(plantProjCount == 3){
					BaseTimer.instance.TimeModifier += 5;
					plantProjCount = 0;
					Destroy( col.gameObject );
					Destroy( this.gameObject );
				}
			}
	}

}
}
