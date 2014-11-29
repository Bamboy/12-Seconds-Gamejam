using UnityEngine;

//By Cristian "vozochris" Vozoca
public class Main : MonoBehaviour
{
	public static MusicPlayer audioPlayer;

	private void Awake()
	{
		AudioHelper.MusicVolume = 0.1f;
		audioPlayer = gameObject.AddComponent<MusicPlayer>();
	}
}