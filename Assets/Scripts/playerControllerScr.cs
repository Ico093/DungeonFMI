using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;

	float moveHorizontal;
	float moveVertical;

	SpriteRenderer sr;
	public Sprite[] states;
	
	void Start () 
	{
		sr = GetComponent<SpriteRenderer>();
		states = Resources.LoadAll<Sprite>("brain");
	}

	void FixedUpdate () 
	{
		PlayerMovement ();
	}

	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		Vector2 direction = new Vector2 ();	
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);

		if (moveHorizontal == 0 && moveVertical > 0) {
			direction.x = 0;
			direction.y = 1;
			sr.sprite = states[3];
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			direction.x = 0;
			direction.y = -1;
			sr.sprite = states[7];
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			direction.x = 1;
			direction.y = 0;
			sr.sprite = states[5];
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			sr.sprite = states[1];
			direction.x = -1;
			direction.y = 0;
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			direction.x = 1;
			direction.y = 1;
			sr.sprite = states[4];
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			direction.x = -1;
			direction.y = 1;
			sr.sprite = states[2];
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			direction.x = 1;
			direction.y = -1;
			sr.sprite = states[6];
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			direction.x = -1;
			direction.y = -1;
			sr.sprite = states[0];
		} else { 
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel ("Dungeon");
	}
}
