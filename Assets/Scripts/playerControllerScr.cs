﻿using UnityEngine;
using System.Collections;

public class playerControllerScr : MonoBehaviour {

	public float movementSpeed;
	public Object projectile;
	public float projectileTimer;

	float moveHorizontal;
	float moveVertical;
	projectileControllerScr projectileHelper;
	
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
