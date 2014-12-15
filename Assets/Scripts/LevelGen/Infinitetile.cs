using UnityEngine;
using System.Collections;

public class Infinitetile : MonoBehaviour 
{
	public GameObject[] prefab;
	public float prefabLength = 50.0f;
	Vector3 position;
	private static float timer = 0.75f;
	public int tileAreaTransitionCount;

	public static int area = 0; //Used by other scripts to know what to spawn. (See LevelGeneration.cs)
	public static int subArea = 0;
	// Use this for initialization
	void Start () {
		position = new Vector3(500, -0.07385421f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//timer -= Time.deltaTime;
		if(timer <= 0)
		{
			position.x -= prefabLength;

			subArea++;
			if( subArea == tileAreaTransitionCount && area != 3 ) //Dont try to go to the next area, just keep looping area 3 forever.
			{
				subArea = 0;
				area++;
			}

			Instantiate(prefab[area], position, Quaternion.identity);

			timer = 3.0f;
		}
	}
	public static void AddTile()
	{
		timer = 0f;
	}
	private void OnApplicationQuit(){
		area = 0;
		subArea = 0;
	}
	private void OnDisable(){
		area = 0;
		subArea = 0;
	}
}