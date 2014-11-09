using UnityEngine;
using System.Collections;

public class FinishLabyrinth : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player")
			Application.LoadLevel ("OutdoorScene");

	}
}
