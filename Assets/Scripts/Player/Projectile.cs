using UnityEngine;
using Enemies;
using Utils;

public class Projectile : MonoBehaviour 
{
	public Vector3 direction;
	public GameObject baseText;
	public Color textColor = Color.green;
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
	void OnTriggerEnter(Collider col)
	{
		switch(col.gameObject.tag)
		{
			case "Crab":
				col.gameObject.GetComponent<Crab>().Hit();
				break;
			
			case "Starfish":
				col.gameObject.GetComponent<Fish>().Hit();
				break;
				
			case "Plant":
				col.gameObject.GetComponent<Plant>().Hit();
				break;
				
			case "Rock":
				col.gameObject.GetComponent<Rock>().Hit();
				break;
				
			case "Dragon":
				BaseTimer.instance.TimeModifier += 1;
				WorldSpaceSpawns.SplatterText.instance.CreateText(col, "+1 Seconds", textColor);
				col.GetComponent<Dragon>().Hit();
				break;
		}
		Destroy(gameObject);
	}
}