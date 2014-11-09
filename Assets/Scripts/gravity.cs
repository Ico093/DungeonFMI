using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {

	float currVelocity = 0;
	float maxVelocity = 10;
	float speed = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (currVelocity < maxVelocity) {
			currVelocity += speed;
				}
		transform.position =new Vector3(transform.position.x, transform.position.y - currVelocity * Time.deltaTime, 0);
	}
}
