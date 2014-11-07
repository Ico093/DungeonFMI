using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;

	void Start () 
	{
	
	}

	void Update () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") ;
		float moveVertical = Input.GetAxis ("Vertical") ;
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
	}
}
