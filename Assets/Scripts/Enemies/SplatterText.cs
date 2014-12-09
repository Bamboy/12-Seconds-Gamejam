using UnityEngine;
using System.Collections;

namespace WorldSpaceSpawns{
	public class SplatterText : MonoBehaviour {
		public static SplatterText instance;
		public GameObject baseText;
		public Color textColor = Color.green;
		public GameObject splatter;

		private void Awake(){
			instance = this;
		}
		public void CreateSplatter( Collider col )
		{
			GameObject splat = (GameObject)Instantiate(splatter, col.gameObject.transform.position + new Vector3(0,0,0.5f), Quaternion.LookRotation(Vector3.up));
			splat.transform.Rotate(0,0,Random.Range(-360,360));
			RaycastHit data;
			if( Physics.Raycast(splat.transform.position, Vector3.down, out data ) )
			{
				splat.transform.position = data.point;
			}
		}
		
		public void CreateText( Collider col, string text, Color color )
		{
			TextDisplay texMesh = ((GameObject)Instantiate(baseText, col.gameObject.transform.position, baseText.transform.rotation)).GetComponent<TextDisplay>();
			if( texMesh != null )
			{
				texMesh.Display( text, color );
			}
			else
				Debug.LogWarning("This script was given a bad baseText prefab! (Needs a TextMesh component)", this);
		}
	}
}