using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
	public GameObject projectile;
	private bool countdown;
	private float timer = 0.75f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(countdown){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			countdown = false;
		}

		if( Input.GetMouseButtonDown(0) && !countdown )
		{
			countdown = true;
			timer = 0.75f;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				//hit.collider.renderer.material.color = Color.red;
			}
			else
				Debug.LogError ("Nothing was hit!", this);


			Vector2 spawnPos = VectorExtras.OffsetPosInPointDirection( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z), 0.6f );
			GameObject proj = (GameObject)Instantiate( projectile, new Vector3( spawnPos.x, 1.0f, spawnPos.y ), Quaternion.identity );
			Vector2 dir = VectorExtras.Direction( new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z) );
			proj.GetComponent<Projectile>().direction = new Vector3( dir.x, 0.0f, dir.y );
			proj.GetComponent<Projectile>().speed += PlyMovement.speed;
		}
	}
}
