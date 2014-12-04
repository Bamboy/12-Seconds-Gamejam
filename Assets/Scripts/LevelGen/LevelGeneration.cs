using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {
	//private GameObject[] spawners;
	public GameObject[] prefabs;
	private float[] counters;
	public float spawnOffset = -30.0f;
	public int min = 3;
	public int max = 7;

	public int[,] weights;
	public static bool doRocks = false;

	private void Start(){
		//spawners = GameObject.FindGameObjectsWithTag("ObjectLane");
		counters = new float[ PlyMovement.laneCount ];
		counters[0] = Random.Range(min, max);
		counters[1] = Random.Range(min, max);
		counters[2] = Random.Range(min, max);
		counters[3] = Random.Range(min, max);
		counters[4] = Random.Range(min, max);

		weights = new int[5,7];

		//---Weights---
		//Beach - Starfish, waves
		weights[0,0] = 40; //Starfish
		weights[0,1] = 58; //waves
		weights[0,2] = 0;  //crab
		weights[0,3] = 0;  //quicksand
		weights[0,4] = 0;  //plants
		weights[0,5] = 2;  //logs
		weights[0,6] = 0;  //rock
		//Desert - Crab, quicksand
		weights[1,0] = 10; //Starfish
		weights[1,1] = 0; //waves
		weights[1,2] = 50;  //crab
		weights[1,3] = 40;  //quicksand
		weights[1,4] = 0;  //plants
		weights[1,5] = 0;  //logs
		weights[1,6] = 0;  //rock
		//Forest - plants, logs
		weights[2,0] = 0; //Starfish
		weights[2,1] = 0; //waves
		weights[2,2] = 5;  //crab
		weights[2,3] = 5;  //quicksand
		weights[2,4] = 45;  //plants
		weights[2,5] = 45;  //logs
		weights[2,6] = 0;  //rock
		//Mountain - dragon, waves, quicksand
		weights[3,0] = 0; //Starfish
		weights[3,1] = 5; //waves
		weights[3,2] = 0;  //crab
		weights[3,3] = 0;  //quicksand
		weights[3,4] = 0;  //plants
		weights[3,5] = 0;  //logs
		weights[3,6] = 95;  //rock
	}
	private void Update(){
		InstantiateCounter(0);
		InstantiateCounter(1);
		InstantiateCounter(2);
		InstantiateCounter(3);
		InstantiateCounter(4);
	}
	private void InstantiateCounter(int number){
		counters[number] -= Time.deltaTime;
		if(counters[number] <= 0)
		{
			if( Infinitetile.area != 3 || (Infinitetile.area == 3 && doRocks == true) )
			{
				SpawnAsset( number );
			}
			counters[number] = Random.Range(min, max);
		}
	}
	void SpawnAsset( int number )
	{
		GameObject prefab = ExtRandom<GameObject>.WeightedChoice( prefabs, weights, Infinitetile.area );
		
		Vector3 pos = new Vector3(PlyMovement.trans.position.x + spawnOffset,0,number * PlyMovement.laneWidth);
		Instantiate(prefab, pos, prefab.transform.rotation);
	}


/*	private int[] GetWeights()
	{
		switch( Infinitetile.area )
		{
			
		}
	}*/
}