using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {
	//private GameObject[] spawners;
	public GameObject[] prefabs;
	private float[] counters;
	public float spawnOffset = -30.0f;

	private void Start(){
		//spawners = GameObject.FindGameObjectsWithTag("ObjectLane");
		counters = new float[ PlyMovement.laneCount ];
		counters[0] = Random.Range(4, 13);
		counters[1] = Random.Range(5, 10);
		counters[2] = Random.Range(7, 12);
		counters[3] = Random.Range(3, 12);
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
			Vector3 pos = new Vector3(PlyMovement.trans.position.x + spawnOffset,0,number * PlyMovement.laneWidth);
			Instantiate(prefabs[prefabNumber], pos, Quaternion.identity);
			//Instantiate(prefabs[prefabNumber], spawners[number].transform.position, Quaternion.identity);
			counters[number] = Random.Range(min, max);
		}
	}
	private IEnumerator wait(int time){
		yield return new WaitForSeconds(time);
	}
}