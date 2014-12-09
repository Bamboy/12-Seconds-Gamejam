using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PlyMovement : CharacterInput 
{
	public static int laneCount = 5;
	public static float laneWidth = 2.5f;
	private static float speed; //This is used for permanant speed changes, such as speed pickups.
	public static float speedMultiplier = 1.0f; //This is used for temporary slows, such as quicksand
	public static Transform trans;
	public static bool RightAnim;
	public static bool LeftAnim;
	public float inspectorSpeed = 6.5f;

	public static int laneNumber;
	private int lastLaneNumber;
	private float time;
	
	public bool drawLanes = true;

	public static float Speed
	{
		get{ return speed; }
		set{ speed = value; speed = Mathf.Clamp( speed, 2.0f, 15.0f ); }
	}

	void Start()
	{
		trans = this.transform;
		time = 1.0f;
		lastLaneNumber = 0;
		laneNumber = 0;
		speedMultiplier = 1.0f;
		speed = inspectorSpeed;
	}

	void Update()
	{
		if(GetRightInput())
		{
			if(laneNumber < laneCount - 1)
			{
				if( !CheckObstacles( Vector3.forward, laneWidth ) ){
					SetLaneNumber( laneNumber + 1 );
					RightAnim = true;
				}
			}
		}
		else if(GetLeftInput())
		{
			if(laneNumber > 0)
			{
				if( !CheckObstacles( Vector3.back, laneWidth ) ){
					SetLaneNumber( laneNumber - 1 );
					LeftAnim = true;
				}
			}
		}
		else{
			LeftAnim = false;
			RightAnim = false;
		}

		time += ( 1.225f * speedMultiplier * Time.deltaTime );

		Vector3 t = transform.position;
		t.z = Mathfx.CustomBerp( lastLaneNumber * laneWidth, laneNumber * laneWidth, time, 1.2f, 3.45f, 6.16f, 0.8f, 2.2f );
		transform.position = t;

		if( !CheckObstacles(Vector3.left, 0.075f) ){
			float currSpeed = speed * speedMultiplier * Time.deltaTime;
			transform.Translate( -1 * currSpeed, 0, 0, Space.World );
		}

#if UNITY_EDITOR
		if( drawLanes )
			DrawLanes();
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
			if( hit.distance <= dist + 0.5f ){
				return true;
			} else {
				return false;
			}
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
