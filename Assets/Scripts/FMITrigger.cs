using UnityEngine;
using System.Collections;

public class FMITrigger : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("trigger");
		Application.LoadLevel ("Dungeon");
	}
}
