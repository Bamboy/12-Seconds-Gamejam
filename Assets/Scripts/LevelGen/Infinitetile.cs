using UnityEngine;
using System.Collections;

public class Infinitetile : MonoBehaviour 
{
	public GameObject prefab;
	public float prefabLength = 50.0f;
	Vector3 position;
	private static float timer = 0.75f;
	public Texture[] tex;
	public int tileAreaTransitionCount;

	public static int area = 0; //Used by other scripts to know what to spawn. (See LevelGeneration.cs)
	public static int subArea = 0;
	// Use this for initialization
	void Start () {
		position = new Vector3(500, -0.07385421f, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//timer -= Time.deltaTime;
		if(timer <= 0)
		{
			position.x -= prefabLength;

			subArea++;
			if( subArea == tileAreaTransitionCount )
			{
				subArea = 0;
				area++;
			}

			GameObject obj = (GameObject)Instantiate(prefab, position, Quaternion.identity);
			obj.renderer.material.mainTexture = tex[area];

			timer = 3.0f;
		}
		//Debug.Log (area + " " + subArea);
	}
	public static void AddTile()
	{
		timer = 0f;
	}
}