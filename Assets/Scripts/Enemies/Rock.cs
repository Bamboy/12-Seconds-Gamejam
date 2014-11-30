using UnityEngine;

namespace Enemies
{
	public class Rock : RotatingEnemy 
	{
		public float timePenalty = 5.0f;
		public Vector2 speedRange;

		private bool hasPassed;
		private bool hasDeducted;
		private void Start() 
		{
			movementSpeed = Random.Range( speedRange.x, speedRange.y );
		}
		
		// Update is called once per frame
		void Update () 
		{
			transform.Translate(movementSpeed * Time.deltaTime, 0, 0, Space.World);
			if(Vector3.Distance(transform.position, Main.player.position) < 2.0f && !hasDeducted)
			{
				hasPassed = true;
			}
			if(hasPassed && !hasDeducted){
				BaseTimer.instance.TimeModifier -= timePenalty;
				hasDeducted = true;
			}
		}
	}
}