using UnityEngine;
using System.Collections;

public class FZFTrigger : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		Application.LoadLevel ("breakout");
	}
}
