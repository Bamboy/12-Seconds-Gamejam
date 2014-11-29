using UnityEngine;
using System.Collections;
using Stats;

public class PlayerUnit : StatObject {
	public Stat movementSpeed;

	protected override void Init (string statsFilePath, params string[] statsJSONPath)
	{
		base.Init (statsFilePath, statsJSONPath);
		movementSpeed = GetStat("movementSpeed");
	}
	private void Awake(){
		Init("Stats/Units/Player");
	}
}