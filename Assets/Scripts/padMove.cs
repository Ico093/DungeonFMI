using UnityEngine;
using System.Collections;

public class padMove : MonoBehaviour {

	public static int n = 5;
	int type;
	public static int[] _value = new int[n];
	int valueIndex = 0;
	public static int _score = 0;

	public float speed;

	public void SetType(int _type) {
		type = _type;
	}

	public void SetValue(int value) {
		_value[type] += value;
	}
	public int[] GetValue() {
		return _value;
	}
	public void SetScore(int score) {
		_score += score;
	}
	public int GetScore() {
		return _score;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	

		Vector3 new_position = new Vector3 (transform.position.x+Input.GetAxis ("Horizontal") * speed * Time.deltaTime, transform.position.y,0);
		transform.position = new_position;


	
	}
}
