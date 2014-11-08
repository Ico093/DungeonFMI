using UnityEngine;
using System.Collections;

public class padMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	

		Vector3 new_position = new Vector3 (transform.position.x+Input.GetAxis ("Horizontal") * speed * Time.deltaTime, transform.position.y,0);
		transform.position = new_position;


	
	}
}
