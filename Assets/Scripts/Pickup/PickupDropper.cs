using UnityEngine;
using System.Collections;

public class PickupDropper : MonoBehaviour 
{
	public static PickupDropper instance;

	public GameObject[] pickups;
	
	public int[] fishWeights;
	public int[] crabWeights;
	public int[] plantWeights;
	public int[] rockWeights;

	void Awake() {
		instance = this;
	}

	public GameObject GetPickupDrop( string enemyType )
	{

		switch (enemyType)
		{
		case "fish":
			return ExtRandom<GameObject>.WeightedChoice( pickups, fishWeights );
		case "crab":
			return ExtRandom<GameObject>.WeightedChoice( pickups, crabWeights );
		case "plant":
			return ExtRandom<GameObject>.WeightedChoice( pickups, plantWeights );
		case "rock":
			return ExtRandom<GameObject>.WeightedChoice( pickups, rockWeights );
		default:
			return null;
		}

	}
}
