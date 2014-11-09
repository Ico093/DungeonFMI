using UnityEngine;
using System.Collections;

public class CameraLooper : MonoBehaviour {


	void onTriggerEnter2D(Collider2D col) {
		Debug.Log ("vvv");
		float widthOfObject = ((BoxCollider2D)col).size.y;
		Vector3 pos = collider.transform.position;
		pos.y += widthOfObject;
	}
}
