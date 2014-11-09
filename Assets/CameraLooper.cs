using UnityEngine;
using System.Collections;

public class CameraLooper : MonoBehaviour {
	public GameObject tiles;

	void Update() {
		Debug.Log (1);
		Vector3 tiles_pos = tiles.transform.position;
		tiles_pos.x = transform.position.x;
		Debug.Log (tiles_pos.y);
		transform.position = tiles_pos;
	}
}
