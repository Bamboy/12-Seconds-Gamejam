using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour 
{
	public float timePenalty = 5.0f;
	public Vector2 speedRange;
	float speed;

	private bool hasPassed;
	private bool hasDeducted;
	void Start () 
	{
		speed = Random.Range( speedRange.x, speedRange.y );
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate( speed * Time.deltaTime, 0, 0, Space.World );
		if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.0f && !hasDeducted)
		{
			hasPassed = true;
		}
		if(hasPassed && !hasDeducted){
			BaseTimer.instance.TimeModifier -= timePenalty;
			hasDeducted = true;
		}
	}
}
