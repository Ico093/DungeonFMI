using UnityEngine;
using System.Collections;

public class LabyrinthMove : MonoBehaviour {
	public float movementSpeed;
		
	float moveHorizontal;
	float moveVertical;
		
	SpriteRenderer sr;
	public Sprite top;
	public Sprite bottom;
	public Sprite left;
	public Sprite right;
	public Sprite topLeft;
	public Sprite topRight;
	public Sprite bottomLeft;
	public Sprite bottomRight;
		
	void Start () 
	{
		sr = GetComponent<SpriteRenderer>();
	}
		
	void FixedUpdate () 
	{
		//Application.LoadLevel ("Dungeon");
		PlayerMovement ();
	}
	public void setTransform(int x, int y) {
		Vector3 coords =new Vector3(x,y,0);
		transform.position = coords;

		}
	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		Vector2 direction = new Vector2 ();	
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
		if (moveHorizontal == 0 && moveVertical > 0) {
			Debug.Log("TOP");
			direction.x = 0;
			direction.y = 1;
			sr.sprite = top;
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			direction.x = 0;
			direction.y = -1;
			sr.sprite = bottom;
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			direction.x = 1;
			direction.y = 0;
			sr.sprite = right;
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			sr.sprite = left;
			direction.x = -1;
			direction.y = 0;
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			direction.x = 1;
			direction.y = 1;
			sr.sprite = topRight;
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			direction.x = -1;
			direction.y = 1;
			sr.sprite = topLeft;
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			direction.x = 1;
			direction.y = -1;
			sr.sprite = bottomRight;
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			direction.x = -1;
			direction.y = -1;
			sr.sprite = bottomLeft;
		} else { 
			//Debug.Log(" default " );
		}
	}
		
		
	void SetDirection()
	{

	}
}
