using UnityEngine;

public class Distancedeleter : MonoBehaviour {
	void FixedUpdate () 
	{
		if( Vector3.Distance( transform.position, Main.player.transform.position ) > 75.0f )
		{
			Destroy(gameObject);
		}
	}
}
