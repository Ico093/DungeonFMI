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
		int rand = Random.Range (1, 1000);
		if(rand>990) 
			zombie = (GameObject) Instantiate (zombie, new Vector3 (0f, 3f, 0f), Quaternion.identity);
	}
}
