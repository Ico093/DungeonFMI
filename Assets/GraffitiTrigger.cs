using UnityEngine;
using System.Collections;

public class GraffitiTrigger : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("trigger");
		Application.LoadLevel ("breakout"); 
	}
}
