using UnityEngine;
using System.Collections;
using Utils;

//By Cristian "vozochris" Vozoca
namespace Enemies
{
	public class Dragon : BaseEnemy
	{
		public Animator anim;
		public BreatheFire fire;
		public Vector2 introPos = Vector2.zero;
		public static Dragon dragon;
		public static bool dragonActive = false;
		public static bool introDone = false;
		public int health;
		public float fireBreatheTime = 1.5f;
		public float fireTimePenalty = 0.05f;
		public Vector2 fireCooldownRange = Vector2.one;
		public Vector2 moveCooldownRange = Vector2.one;
		private int lane = 2; //What lane we are in. Start in the middle.
		private int lastLane = 2;
		private float time = 0.0f;

		//Behaviour bools
		private bool doneBreathingFire = true;

		protected override void Awake()
		{
			base.Awake();
			dragon = this;
		}
		public void Init()
		{
			Debug.Log ("Dragon Started!");
			StartCoroutine("Move");
			dragonActive = true;
		}


		protected override void Update()
		{
			if( dragonActive == true )
			{
				if( time > 1.3f || introDone ) //Time is not used until the intro has been completed, so we might as well use it for the intro as well.
				{
					DoAI();
					if( introDone == false )
					{
						introDone = true;
						LevelGeneration.doRocks = true; //Spawn rocks.
						time = 0.0f;
						StartCoroutine("Move");
						StartCoroutine("BreatheFire");
					}
				}
				else // Do the intro
				{
					time += ( 0.45f * Time.deltaTime );
					Vector3 t = transform.position;
					t.x = Mathfx.Sinerp( Main.player.position.x + introPos.x, Main.player.position.x + introPos.y, time );
					transform.position = t;
				}
			}

			movementSpeed = -PlyMovement.Speed;
			base.Update();
		}

		void DoAI()
		{
			//Changing lanes
			time += ( 2.06f * Time.deltaTime );
			Vector3 t = transform.position;
			t.z = Mathfx.Sinerp( lastLane * PlyMovement.laneWidth, lane * PlyMovement.laneWidth, time );
			//t.z = Mathfx.CustomBerp( lastLane * PlyMovement.laneWidth, lane * PlyMovement.laneWidth, time, 1.2f, 3.45f, 6.16f, 0.8f, 2.2f );
			transform.position = t;

			DoFireDamage(); //Do fire damage if we are breathing fire.
		}
		//======== Movement ==============
		public IEnumerator Move()
		{
			while( doneBreathingFire == false || introDone == false )
				yield return null; //Wait until we are done breathing fire before moving.

			if(VectorExtras.SplitChance() == true) //Move randomly to the left or right
				MoveRight ();
			else
				MoveLeft ();

			yield return new WaitForSeconds( Random.Range(moveCooldownRange.x, moveCooldownRange.y) );

			StartCoroutine("Move"); //Loop this yield.
		}
		void MoveRight()
		{
			if(lane < PlyMovement.laneCount - 1)
			{
				time = 0.0f;
				lastLane = lane;
				lane++;
			}
			else
				MoveLeft ();
		}
		void MoveLeft()
		{
			if(lane > 0)
			{
				time = 0.0f;
				lastLane = lane;
				lane--;
			}
			else
				MoveRight ();
		}

		//======== Fire Breathing ==============
		void DoFireDamage()
		{
			if( fire.IsBreathingFire() == true && PlyMovement.laneNumber == lane )
			{
				BaseTimer.instance.TimeModifier -= fireTimePenalty;
			}
		}
		public IEnumerator BreatheFire()
		{
			yield return new WaitForSeconds( Random.Range(fireCooldownRange.x, fireCooldownRange.y) );

			doneBreathingFire = false;
			anim.SetBool ("breatheFire", true);
			yield return new WaitForSeconds( fireBreatheTime + 0.25f ); //0.25f is the intro animation time.
			anim.SetBool ("breatheFire", false);
			yield return new WaitForSeconds( 0.5f ); //0.5f is the outro animation time.
			doneBreathingFire = true;

			StartCoroutine("BreatheFire"); //Loop this yield.
		}

		public void Hit()
		{
			if( dragonActive )
			{
				health--;
				if (health == 0)
				{
					Die ();
				}
			}
		}

		public override void Die ()
		{
			Destroy(gameObject);
		}
	}
}