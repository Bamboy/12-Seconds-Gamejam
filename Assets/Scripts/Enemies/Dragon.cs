using UnityEngine;
using System.Collections;
using Utils;
using Utils.Audio;
using Excelsion.UI;

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
		public float fireBreatheTime = 1.5f;
		public float fireTimePenalty = 0.05f;
		public Vector2 fireCooldownRange = Vector2.one;
		public Vector2 moveCooldownRange = Vector2.one;
		private int lane = 2; //What lane we are in. Start in the middle.
		private int lastLane = 2;
		private float time = 0.0f;
		private AudioSource breathAudio;

		//Behaviour bools
		private bool doneBreathingFire = true;
		private bool doneMoving
		{ get{ return time >= 1.0f; } }

		public int Health
		{ get{ return health; }set{ health = value; }}

		protected override void Awake()
		{
			base.Awake();
			breathAudio = GetComponent<AudioSource>();
			dragon = this;
			health = 250;
			timePenalty = 0.0f; //The dragon will never come in contact with the player.
		}
		public void Init()
		{
			//Debug.Log ("Dragon Started!");
			StartCoroutine("Move");
			dragonActive = true;
		}
		public static void Reset()
		{
			dragon = null;
			dragonActive = false;
			introDone = false;
		}


		protected override void Update()
		{
			if( Main.GamePaused )
				breathAudio.volume = 0.0f;
			else
				breathAudio.volume = AudioHelper.GetVolume( 0.9f, SoundType.Effect );

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
					LevelGeneration.doRocks = false;
					time += ( 0.45f * Time.deltaTime );
					Vector3 t = transform.position;
					t.x = Mathfx.Sinerp( Main.player.position.x + introPos.x, Main.player.position.x + introPos.y, time );
					transform.position = t;
				}
				//Debug.Log( time );
			}

			movementSpeed = -PlyMovement.Speed;
			base.Update();
		}

		void DoAI()
		{
			//Changing lanes
			if( doneBreathingFire )
				time = Mathf.Clamp01(time + ( 2.06f * Time.deltaTime ));
			else
				DoFireDamage(); //Do fire damage if we are breathing fire.

			Vector3 t = transform.position;
			t.z = Mathfx.Sinerp( lastLane * PlyMovement.laneWidth, lane * PlyMovement.laneWidth, time );
			//t.z = Mathfx.CustomBerp( lastLane * PlyMovement.laneWidth, lane * PlyMovement.laneWidth, time, 1.2f, 3.45f, 6.16f, 0.8f, 2.2f );
			transform.position = t;

			 
		}
		//======== Movement ==============
		public IEnumerator Move()
		{
			//WAIT until we are done breathing fire before moving.
			while( doneBreathingFire == false || introDone == false )
				yield return null; 

			if(VectorExtras.SplitChance() == true) //Move randomly to the left or right
				MoveRight ();
			else
				MoveLeft ();

			//WAIT until we are finished changing lanes before starting our cooldown!
			while(doneMoving == false)
				yield return null;

			//Debug.Log( "Movecooldown start!" );

			//WAIT until we are finished with our movement cooldown
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

			//Wait until we're done changing lanes.
			while(doneMoving == false)
				yield return null;

			doneBreathingFire = false;
			anim.SetBool ("breatheFire", true);
			breathAudio.Play();
			yield return new WaitForSeconds( fireBreatheTime + 0.25f ); //0.25f is the intro animation time.
			anim.SetBool ("breatheFire", false);
			breathAudio.Stop();
			yield return new WaitForSeconds( 0.5f ); //0.5f is the outro animation time.
			doneBreathingFire = true;


			StartCoroutine("BreatheFire"); //Loop this yield.
		}

		public override void OnTakeDamage( int value )
		{
			if( dragonActive )
			{
				health -= value;
				if (health <= 0)
				{
					BaseTimer.instance.TimeModifier += 120.0f;
					ButtonFunctions.instance.ForceWinDisplay();
					Kill();
				}
				else
				{
					BaseTimer.instance.TimeModifier += 0.5f;
				}
			}
		}




		protected override void DropPowerUp() { return; }








	}
}