using UnityEngine;
using System.Collections;

public class ball_move : MonoBehaviour {

	// Constant speed of the ball
	public float speed = 5f;
	public GameObject pad;
	
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
