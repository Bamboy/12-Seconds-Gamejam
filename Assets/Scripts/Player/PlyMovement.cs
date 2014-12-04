using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PlyMovement : MonoBehaviour {
	public static int laneCount = 5;
	public static float laneWidth = 2.5f;
	public static float speed;
	public static float speedMultiplier = 1.0f;
	public static float currSpeed;
	public static Transform trans;
	public float inspectorSpeed = 6.5f;

	public static int laneNumber;
	private int lastLaneNumber;
	private float time;
	
	public bool drawLanes = true;

	//Android
	private Vector2 firstPosition;
	private Vector2 lastPosition;

	void Start()
	{
		trans = this.transform;
		time = 1.0f;
		lastLaneNumber = 0;
		laneNumber = 0;
	}

	void Update()
	{
#if UNITY_STANDALONE
		speed = inspectorSpeed;
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(laneNumber < laneCount - 1)
			{
				if( !CheckObstacles( Vector3.forward, laneWidth ) )
					SetLaneNumber( laneNumber + 1 );
			}
		} 
		else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(laneNumber > 0)
			{
				if( !CheckObstacles( Vector3.back, laneWidth ) )
					SetLaneNumber( laneNumber - 1 );
			}
		}
		time += ( 1.225f * speedMultiplier * Time.deltaTime );

		Vector3 t = transform.position;
		t.z = Mathfx.CustomBerp( lastLaneNumber * laneWidth, laneNumber * laneWidth, time, 1.2f, 3.45f, 6.16f, 0.8f, 2.2f );
		transform.position = t;

		if( !CheckObstacles(Vector3.left, 0.075f) )
			currSpeed = speed * speedMultiplier * Time.deltaTime;
			transform.Translate( -1 * currSpeed, 0, 0, Space.World );
#endif
#if UNITY_EDITOR
		if( drawLanes )
			DrawLanes();
#endif
#if UNITY_ANDROID
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				firstPosition = touch.position;
				lastPosition = touch.position;
			}
			if(touch.phase == TouchPhase.Moved){
				lastPosition = touch.position;
			}
			if(touch.phase == TouchPhase.Ended){
				if(firstPosition.x - lastPosition.x > 80){//swipe left
					if(laneNumber > 0)
					{
						if( !CheckObstacles( Vector3.back, laneWidth ) )
							SetLaneNumber( laneNumber - 1 );
					}
				}
				if(firstPosition.x - lastPosition.x < -80){//swipe right
					if(laneNumber < laneCount - 1)
					{
						if( !CheckObstacles( Vector3.forward, laneWidth ) )
							SetLaneNumber( laneNumber + 1 );
					}
				}
			}
		}
		speed = inspectorSpeed;
		time += ( 1.225f * speedMultiplier * Time.deltaTime );
		
		Vector3 t = transform.position;
		t.z = Mathfx.CustomBerp( lastLaneNumber * laneWidth, laneNumber * laneWidth, time, 1.2f, 3.45f, 6.16f, 0.8f, 2.2f );
		transform.position = t;
		
		if( !CheckObstacles(Vector3.left, 0.075f) )
			currSpeed = speed * speedMultiplier * Time.deltaTime;
		transform.Translate( -1 * currSpeed, 0, 0, Space.World );
#endif
	}
	void SetLaneNumber( int newLane )
	{
		lastLaneNumber = laneNumber;
		laneNumber = newLane;
		time = 0.0f;
	}

	bool CheckObstacles( Vector3 dir, float dist )
	{
		RaycastHit hit;
		if( Physics.Raycast( transform.position, dir, out hit ) )
		{
			if( hit.distance <= dist + 0.5f )
				return true;
			else
				return false;
		}
		else
			return false;
	}

	void DrawLanes()
	{
		for( int i = 0; i < laneCount; i++ )
		{
			Debug.DrawLine(new Vector3( -99999, 0.1f, i * laneWidth ), new Vector3( 99999, 0.1f, i * laneWidth ), Color.blue, 1.0f);
		}
	}
}
