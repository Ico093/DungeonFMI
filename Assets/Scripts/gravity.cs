using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {

	float currVelocity = 0;
	float maxVelocity = 10;
	float speed = 0.5f;
	string type;
	int value;
	int score;

	GameObject pad;

	public void SetType(string _type) {
		type = _type;
	}
	public string getType() {
		return type;
	}
	
	public void SetValue(int _value) {
		value = _value;
	}
	public int GetValue() {
		return value;
	}
	public void SetScore(int _score) {
		score = _score;
	}
	public int GetScore() {
		return score;
	}

	// Use this for initialization
	void Start(){
		pad = GameObject.Find ("pad");
		}
	
	// Update is called once per frame
	void Update () {
		if (currVelocity < maxVelocity) {
			currVelocity += speed;
				}
		transform.position =new Vector3(transform.position.x, transform.position.y - currVelocity * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "pad") {
			var another = other.GetComponent<padMove>();
			another.SetScore(GetScore());
			another.SetType(int.Parse(getType()));
			another.SetValue(GetValue());
				}
					
	}
}
