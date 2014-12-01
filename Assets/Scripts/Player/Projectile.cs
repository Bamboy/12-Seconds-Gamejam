using UnityEngine;
using Enemies;


public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
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
	void OnTriggerEnter(Collider col)
	{
		switch(col.gameObject.tag)
		{
			case "Crab":
				crabProjCount++;
				if(crabProjCount == 2)
				{
					BaseTimer.instance.TimeModifier += 3;
					crabProjCount = 0;
					Destroy( col.gameObject );
				}
				break;
			
			case "Starfish":
				BaseTimer.instance.TimeModifier += 2;
				starfishProjCount = 0;
				Destroy( col.gameObject );
				break;
				
			case "Plant":
				plantProjCount++;
			    if(plantProjCount == 3)
				{
					BaseTimer.instance.TimeModifier += 5;
					plantProjCount = 0;
					Destroy( col.gameObject );
				}
				break;
				
			case "Rock":
				BaseTimer.instance.TimeModifier += 5;
				Destroy( col.gameObject );
				break;
				
			case "Dragon":
				BaseTimer.instance.TimeModifier += 5;
				col.GetComponent<Dragon>().Hit();
				break;
		}
		Destroy(gameObject);
	}
}
