using UnityEngine;
using System.Collections;

public class dropScr : MonoBehaviour {

	string type;
	int value;
	int score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(string _type) {
		type = _type;
		Debug.Log (type);
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

}
