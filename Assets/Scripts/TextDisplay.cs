using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour 
{
	public TextMesh fg;
	public TextMesh bg;
	public float riseSpeed = 1.0f;

	public void Display( string text, Color color )
	{
		if( fg == null || bg == null )
		{ return; }

		fg.text = text;
		bg.text = text;

		fg.color = color;
		bg.color = Color.black;
	}

	void Update()
	{
		transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
	}
}
