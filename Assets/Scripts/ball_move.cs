﻿using UnityEngine;
using System.Collections;

public class ball_move : MonoBehaviour {

	// Constant speed of the ball
	public float speed = 5f;
	public GameObject pad;
	public GameObject drop;
	
	// Keep track of the direction in which the ball is moving
	private Vector2 velocity;
	
	// used for velocity calculation
	private Vector2 lastPos;
	
	void Start ()
	{
		// Random direction
		rigidbody2D.velocity = new Vector2(1,1).normalized * speed;
	}
	
	void FixedUpdate ()
	{
		// Get pos 2d of the ball.
		Vector3 pos3D = transform.position;
		Vector2 pos2D = new Vector2(pos3D.x, pos3D.y);
		
		// Velocity calculation. Will be used for the bounce
		velocity = pos2D - lastPos;
		lastPos = pos2D;
	}

	private void OnTriggerEnter2D ( Collider2D other) 
	{
		if (other.tag == "bottom_line") {
			Debug.Log("umre");
				}

		}
	private void OnCollisionEnter2D(Collision2D col)
	{
		int multy = 1;
		float diff = 1;
		if (col.gameObject.tag == "brick") {
			GameObject BG = GameObject.Find("Background");
			var function=BG.GetComponent<ConstructBG>();
			function.DestroyedBrick();
			Destroy(col.gameObject);
			if(Random.Range (1, 100) > 50)
			{
				var tempDrop = Instantiate(drop, col.transform.position, Quaternion.identity) as GameObject;
				tempDrop.rigidbody2D.gravityScale = 1;
				Destroy (tempDrop.rigidbody2D);
				tempDrop.AddComponent<gravity>();
				var tempDropHelper = tempDrop.GetComponent<dropScr>();
				tempDropHelper.SetScore(100);
				int type = Random.Range (1, 5);
				switch (type)
				{
				case 1:
					tempDropHelper.SetType("ms");
					tempDropHelper.SetValue(2);
					break;
				case 2:
					tempDropHelper.SetType ("as");
					tempDropHelper.SetValue(1); 	//how many tenths of a second the as is improved
					break;
				case 3:
					tempDropHelper.SetType("boostHP");
					tempDropHelper.SetValue(100);
					break;
				case 4:
					tempDropHelper.SetType("bigeer,faster,stroger,better");
					tempDropHelper.SetValue(10);	//percent value
					break;
				default:
					break;
				}
			}
				}
		if (col.gameObject.tag == "pad") 
			diff = (this.transform.position.x- pad.transform.position.x) / 3f + 1;
		// Normal
		Vector3 N = col.contacts[0].normal;
		
		//Direction
		Vector3 V = velocity.normalized;
		
		// Reflection
		Vector3 R = Vector3.Reflect(V, N).normalized;
		// Assign normalized reflection with the constant speed
		if (R.y == 0) R.y = 0.5f;
		rigidbody2D.velocity = new Vector2(R.x*diff, R.y*1.1f).normalized * speed * multy;
	}
}
