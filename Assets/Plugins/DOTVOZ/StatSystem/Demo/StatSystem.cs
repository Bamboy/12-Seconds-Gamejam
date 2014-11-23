using UnityEngine;

//By Cristian "vozochris" Vozoca
namespace Stats.Demo
{
	public class StatSystem : MonoBehaviour
	{
		private void Awake()
		{
			GameObject playerGO = new GameObject("Player");
			playerGO.AddComponent<Player>();
		}
	}
}