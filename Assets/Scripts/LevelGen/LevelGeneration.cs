using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {
	//private GameObject[] spawners;
	public GameObject[] prefabs;
	private float[] counters;
	public float spawnOffset = -30.0f;

	public int[,] weights;

	private void Start(){
		//spawners = GameObject.FindGameObjectsWithTag("ObjectLane");
		counters = new float[ PlyMovement.laneCount ];
		counters[0] = Random.Range(4, 13);
		counters[1] = Random.Range(5, 10);
		counters[2] = Random.Range(7, 12);
		counters[3] = Random.Range(3, 12);

		weights = new int[4,7];

		//---Weights---
		//Beach - Starfish, waves
		weights[0,0] = 60; //Starfish
		weights[0,1] = 40; //waves
		weights[0,2] = 0;  //crab
		weights[0,3] = 0;  //quicksand
		weights[0,4] = 0;  //plants
		weights[0,5] = 0;  //logs
		weights[0,6] = 0;  //Dragon
		//Desert - Crab, quicksand
		weights[1,0] = 10; //Starfish
		weights[1,1] = 0; //waves
		weights[1,2] = 50;  //crab
		weights[1,3] = 40;  //quicksand
		weights[1,4] = 0;  //plants
		weights[1,5] = 0;  //logs
		weights[1,6] = 0;  //Dragon
		//Forest - plants, logs
		weights[2,0] = 0; //Starfish
		weights[2,1] = 0; //waves
		weights[2,2] = 5;  //crab
		weights[2,3] = 5;  //quicksand
		weights[2,4] = 45;  //plants
		weights[2,5] = 45;  //logs
		weights[2,6] = 0;  //Dragon
		//Mountain - dragon, waves, quicksand
		weights[3,0] = 0; //Starfish
		weights[3,1] = 30; //waves
		weights[3,2] = 0;  //crab
		weights[3,3] = 20;  //quicksand
		weights[3,4] = 0;  //plants
		weights[3,5] = 0;  //logs
		weights[3,6] = 50;  //Dragon
	}
	private void Update(){
		InstantiateCounter(0, 0, 4, 13);
		InstantiateCounter(1, 0, 5, 10);
		InstantiateCounter(2, 0, 7, 9);
		InstantiateCounter(3, 0, 3, 12);
	}
	private void InstantiateCounter(int number, int prefabNumber, int min, int max){
		counters[number] -= Time.deltaTime;
		if(counters[number] <= 0)
		{
			GameObject prefab = ExtRandom<GameObject>.WeightedChoice( prefabs, weights, Infinitetile.area );

			Vector3 pos = new Vector3(PlyMovement.trans.position.x + spawnOffset,0,number * PlyMovement.laneWidth);
			Instantiate(prefab, pos, prefab.transform.rotation);
			//Instantiate(prefabs[prefabNumber], spawners[number].transform.position, Quaternion.identity);
			counters[number] = Random.Range(min, max);
		}
	}
	private IEnumerator wait(int time){
		yield return new WaitForSeconds(time);
	}

/*	private int[] GetWeights()
	{
		switch( Infinitetile.area )
		{
			
		}
	}*/
}