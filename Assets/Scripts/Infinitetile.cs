using UnityEngine;
using System.Collections;

public class Infinitetile : MonoBehaviour {
	public GameObject tile;
	public GameObject prefab;
	Vector3 position;
	private float timer = 0.75f;
	public Texture[] tex;
	public int tileAreaTransitionCount;

	public static int area = 0;
	public static int subArea;
	// Use this for initialization
	void Start () {
		position  = new Vector3(-9.86707f, -0.07385421f, 1.151482f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0)
		{
			position.x -= (float)30;

			subArea++;
			if( subArea == tileAreaTransitionCount )
			{
				subArea = 0;
				area++;
			}

			GameObject obj = (GameObject)Instantiate(prefab, position, Quaternion.identity);
			obj.renderer.material.mainTexture = tex[area];

			timer = 3f;
		}
		Debug.Log (area + " " + subArea);
	}
}