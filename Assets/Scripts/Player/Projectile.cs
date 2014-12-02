using UnityEngine;
using Enemies;


public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public GameObject splatter;
	public float speed = 3.0f;

	void Start()
	{
		rigidbody.AddForce( direction * speed, ForceMode.Impulse );
		Invoke ("Remove", 5);
	}

	private void Remove()
	{
		Destroy(gameObject);
	}


	//// Update is called once per frame
	//void Update () 
	//{
	//	transform.Translate( direction * speed * Time.deltaTime );
	//}

	private static float crabProjCount = 0;
	private static float plantProjCount = 0;
	private static float starfishProjCount = 0;
	private static float rockProjCount = 0;
	void OnTriggerEnter(Collider col)
	{
		switch(col.gameObject.tag)
		{
			case "Crab":
				crabProjCount++;
				if(crabProjCount == 3)
				{
					BaseTimer.instance.TimeModifier += 3;
					crabProjCount = 0;
					Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
					Destroy( col.gameObject );
				}
				break;
			
			case "Starfish":
				starfishProjCount++;
				if(starfishProjCount == 3){
					BaseTimer.instance.TimeModifier += 2;
					starfishProjCount = 0;
					Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
					Destroy( col.gameObject );
				}
				break;
				
			case "Plant":
				plantProjCount++;
			    if(plantProjCount == 4)
				{
					BaseTimer.instance.TimeModifier += 5;
					plantProjCount = 0;
					Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
					Destroy( col.gameObject );
				}
				break;
				
			case "Rock":
				rockProjCount++;
				if(rockProjCount == 4){
					BaseTimer.instance.TimeModifier += 5;
					rockProjCount = 0;
					Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
					Destroy( col.gameObject );
				}
				break;
				
			case "Dragon":
				BaseTimer.instance.TimeModifier += 5;
				col.GetComponent<Dragon>().Hit();
				break;
		}
		Destroy(gameObject);
	}
}
