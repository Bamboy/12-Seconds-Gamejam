﻿using UnityEngine;
using System.Collections;

public class PlyMovement : MonoBehaviour {
	public static int laneCount = 4;
	public static float laneWidth = 2.5f;
	public static float speed = 1.0f;
	public float inspectorSpeed = 7.5f;
	private int laneNumber;

	public LayerMask layers;
	public bool drawLanes = true;
	public static Transform trans;

	void Update()
	{
		trans = this.transform;
		speed = inspectorSpeed;
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(laneNumber < laneCount - 1)
			{
				if( !CheckObstacles( Vector3.forward, laneWidth ) )
					laneNumber++;
			}
		} 
		else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(laneNumber > 0)
			{
				if( !CheckObstacles( Vector3.back, laneWidth ) )
					laneNumber--;
			}
		}

		Vector3 t = transform.position;
		t.z = laneNumber * laneWidth;
		transform.position = t;

		if( !CheckObstacles(Vector3.left, 0.075f) )
			transform.Translate( -1 * speed * Time.deltaTime, 0, 0, Space.World );

		if( drawLanes )
			DrawLanes();
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
