using UnityEngine;
using System.Collections;

public class dungeonPlayerScr : MonoBehaviour {
	
	public float movementSpeed;
	public GameObject projectile;
	float projectileTimer = 0.4f;
	int mode = 3;
	
	float moveHorizontal;
	float moveVertical;
	Vector2 direction = new Vector2(0, 1);

	public void SetMode(int m)
	{
		mode = m;
	}
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		PlayerMovement ();
		ShootLogic ();
	}
	
	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
		SetDirection ();
	}
	
	void ShootLogic()
	{
		projectileTimer -= Time.deltaTime;
		if (projectileTimer <= 0 && Input.GetKeyDown(KeyCode.Space)) {
			ShootMode (mode);
			projectileTimer = 0.4f;
		}
	}

	void ShootMode(int mode)
	{
		switch (mode) 
		{
		case 1:
			Shoot (0f);
			break;
		case 2:
			Shoot (-45f);
			Shoot (45f);
			break;
		case 3:
			Shoot (0f);
			Shoot (-45f);
			Shoot (45f);
			break;
		default:
			Shoot (0f);
			break;
		}
	}

	void Shoot(float angle)
	{
		Vector2 tempDirection = direction;
		if (angle != 0.0f)
		{
			float rad = (angle * Mathf.PI) / 180;
			Matrix4x4 rotMatrix = new Matrix4x4();
			rotMatrix.SetRow(0, new Vector4(Mathf.Cos (rad), -Mathf.Sin (rad), 0 ,0));
			rotMatrix.SetRow(1, new Vector4(Mathf.Sin (rad), Mathf.Cos (rad), 0 ,0));
			rotMatrix.SetRow(2, new Vector4(0, 0, 1 ,0));
			rotMatrix.SetRow(3, new Vector4(0, 0, 0 ,1));
			Debug.Log (rotMatrix.m00);
			Debug.Log (rotMatrix.m01);
			Debug.Log (rotMatrix.m10);
			Debug.Log (rotMatrix.m11);
			Debug.Log (rad);
			tempDirection = rotMatrix * direction;
		}
		var tempProjectile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		var projectileHelper = tempProjectile.GetComponent<projectileControllerScr> ();
		projectileHelper.SetTargetPosition (tempDirection.normalized);
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
