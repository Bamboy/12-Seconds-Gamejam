using UnityEngine;
using System.Collections;

namespace Excelsion.Utils{
	public class InvokeNextScene : MonoBehaviour {
		private void Awake(){
			Invoke("NextScene", 50f);
		}
		private void NextScene(){
			Application.LoadLevel(3);
		}
	}
}