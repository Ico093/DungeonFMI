using UnityEngine;
using System.Collections;

public class dungeonPlayerScr : MonoBehaviour {
	
	public float movementSpeed;
	public GameObject projectile;
	float projectileTimer = 0.4f;
	
	float moveHorizontal;
	float moveVertical;
	Vector2 direction = new Vector2(0, 1);
	
	void Start () 
	{
		
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
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
		SetDirection ();
	}
	
	void Shoot()
	{
		projectileTimer -= Time.deltaTime;
		if (projectileTimer <= 0 || Input.GetKeyDown(KeyCode.Space)) {
			var tempProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			var projectileHelper = tempProjectile.GetComponent<projectileControllerScr>();
			projectileHelper.SetTargetPosition(direction);
			projectileTimer = 0.4f;
		}
	}

	void SetDirection()
	{
		if (moveHorizontal == 0 && moveVertical > 0) {
			direction.x = 0;
			direction.y = 1;
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			direction.x = 0;
			direction.y = -1;
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			direction.x = 1;
			direction.y = 0;
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			direction.x = -1;
			direction.y = 0;
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			direction.x = 1;
			direction.y = 1;
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			direction.x = -1;
			direction.y = 1;
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			direction.x = 1;
			direction.y = -1;
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			direction.x = -1;
			direction.y = -1;
		}
	}
}
