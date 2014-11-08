using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;
	public Object projectile;
	public float projectileTimer;

	float moveHorizontal;
	float moveVertical;
	projectileControllerScr projectileHelper;

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

	void Update () 
	{
		PlayerMovement ();
		Shoot ();
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
			Debug.Log(" default " );
		}
	}

	void Shoot()
	{
		projectileTimer -= Time.deltaTime;
		if (projectileTimer <= 0 || Input.GetKeyDown(KeyCode.Space)) {
			projectile = Instantiate(projectile, transform.position, Quaternion.identity);
			projectileHelper = GetComponent<projectileControllerScr>();
			projectileHelper.SetTargetPosition(new Vector2(1, 0));
			projectileTimer = 2;
		}
	}

	void SetDirection()
	{

	}
}
