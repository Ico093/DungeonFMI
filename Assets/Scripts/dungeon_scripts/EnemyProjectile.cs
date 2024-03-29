﻿using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	public float projectileSpeed;
	int dmg;
	
	Vector2 projectileStartPosition;
	Vector2 projectileTargetPosition;
	
	Vector2 projectileDirection = new Vector2(1, 1);
	
	// Use this for initialization
	void Start ()
	{
		projectileStartPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position += (Vector3)projectileDirection * projectileSpeed * Time.deltaTime;		
	}
	public void setSpeed(float speed) {
		projectileSpeed *= speed/2f;

	}
	public void SetTargetPosition(Vector2 target)
	{
		Matrix4x4 matrix = new Matrix4x4 ();
		matrix.SetRow (0, new Vector4 (target.x, 0, 0, 0));
		matrix.SetRow (1, new Vector4 (0, target.y, 0, 0));
		matrix.SetRow (2, new Vector4 (0, 0, 1, 0));
		matrix.SetRow (3, new Vector4 (0, 0, 0, 1));
		Vector2 tempVector = matrix.MultiplyVector (new Vector4 (projectileDirection.x, projectileDirection.y, 0, 0));
		projectileTargetPosition = projectileStartPosition + tempVector;
		projectileDirection = projectileTargetPosition - projectileStartPosition;
		projectileDirection.Normalize ();
	}

	public void Rotate(float angle)
	{
		transform.Rotate (new Vector3 (0, 0, angle));
		}
	
	public void SetDamage(int damage)
	{
		dmg = damage;
	}
	
	public int GetDamage()
	{
		return dmg;
	}
	
	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag =="arenaWall")
			Destroy (this.gameObject);
	}
	


}
