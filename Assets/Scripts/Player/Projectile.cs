using UnityEngine;
using Enemies;


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
					CreateSplatter( col );
					CreateText( col, "+3 Sec", textColor );
					Destroy( col.gameObject );
				}
				break;
			
			case "Starfish":
				starfishProjCount++;
				if(starfishProjCount == 3){
					BaseTimer.instance.TimeModifier += 2;
					starfishProjCount = 0;
					CreateSplatter( col );
					CreateText( col, "+2 Sec", textColor );
					Destroy( col.gameObject );
				}
				break;
				
			case "Plant":
				plantProjCount++;
			    if(plantProjCount == 4)
				{
					BaseTimer.instance.TimeModifier += 5;
					plantProjCount = 0;
					CreateSplatter( col );
					CreateText( col, "+5 Sec", textColor );
					Destroy( col.gameObject );
				}
				break;
				
			case "Rock":
				rockProjCount++;
				if(rockProjCount == 4){
					BaseTimer.instance.TimeModifier += 12;
					rockProjCount = 0;
					CreateSplatter( col );
					CreateText( col, "+12 Sec", textColor );
					Destroy( col.gameObject );
				}
				break;
				
			case "Dragon":
				BaseTimer.instance.TimeModifier += 1;
				CreateText( col, "+1 Sec", textColor );
				col.GetComponent<Dragon>().Hit();
				break;
		}
		Destroy(gameObject);
	}

	void CreateSplatter( Collider col )
	{
		GameObject splat = (GameObject)Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
		splat.transform.Rotate(0,0,Random.Range(-360,360));
		RaycastHit data;
		if( Physics.Raycast(splat.transform.position, Vector3.down, out data ) )
		{
			splat.transform.position = data.point;
		}
	}

	void CreateText( Collider col, string text, Color color )
	{
		TextDisplay texMesh = ((GameObject)Instantiate(baseText, col.gameObject.transform.position, baseText.transform.rotation)).GetComponent<TextDisplay>();
		if( texMesh != null )
		{
			texMesh.Display( text, color );
		}
		else
			Debug.LogWarning("This script was given a bad baseText prefab! (Needs a TextMesh component)", this);
	}



}
