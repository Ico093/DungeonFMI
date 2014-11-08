using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;

	float moveHorizontal;
	float moveVertical;
	
	void Start () 
	{

	}

	void Update () 
	{
		PlayerMovement ();
	}

	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
	}
}
