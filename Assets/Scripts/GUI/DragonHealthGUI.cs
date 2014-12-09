using UnityEngine;
using System.Collections;

public class DragonHealthGUI : MonoBehaviour {
	public Texture2D healthBar;
	public int dragonHealthInitial;
	private void Start()
	{
		dragonHealthInitial = Enemies.Dragon.dragon.Health;
	}
	private void Update () {
		Debug.DrawRay(this.transform.position, Vector3.right * 50);
	}
	private void OnGUI(){
		if(Vector3.Distance(this.transform.position, Main.player.position) < 40.0f){
			GUI.BeginGroup(new Rect((Screen.width/2) - 125, 10, 250, 20));
			GUI.Box(new Rect(0, 0, 250, 20), "");
			GUI.DrawTexture(new Rect(2, 2, 246 * Enemies.Dragon.dragon.Health / dragonHealthInitial, 16), healthBar);
			GUI.EndGroup();
		}
	}
}
