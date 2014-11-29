using UnityEngine;
using System.Collections;

public class wave : MonoBehaviour {
	public float timePenalty = 5.0f;
	public float speed = 5.0f;
	public float texSpeed = 0.2f;
	private bool hasPassed;
	private bool hasDeducted;
	private float xOffset;
	void Start()
	{
		renderer.material.mainTextureScale = new Vector2( 0.5f, 0.5f );
		xOffset = Random.value;
	}
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

		Vector2 offset = renderer.material.mainTextureOffset;
		offset.y -= (texSpeed * Time.deltaTime);
		renderer.material.mainTextureOffset = new Vector2(xOffset, offset.y);
	}
}
