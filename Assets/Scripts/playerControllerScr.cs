using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;

	void Start () 
	{
	
	}

	void Update () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;
		float moveVertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0));
	}
}
