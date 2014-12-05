using UnityEngine;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static Transform player;

	public static MusicPlayer audioPlayer;

	private void Awake()
	{
		AudioHelper.MusicVolume = 0.1f;
		audioPlayer = gameObject.AddComponent<MusicPlayer>();

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public static bool OnWin()
	{
		if(Enemies.Dragon.dragon.health <= 0){
			return true;
		} else {
			return false;
		}
	}
}