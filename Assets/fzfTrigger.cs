using UnityEngine;
using System.Collections;

public class fzfTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("trigger");
		Application.LoadLevel ("arena");
	}
}
