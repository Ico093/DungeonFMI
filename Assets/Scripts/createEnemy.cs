using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour {

	public GameObject zombie;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int rand = Random.Range (1, 100);
		if(rand>900) 
			zombie = (GameObject) Instantiate (zombie, new Vector3 (0f, 3f, 0f), Quaternion.identity);
	}
}
