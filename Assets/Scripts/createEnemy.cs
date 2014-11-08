using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour {

	public GameObject zombie;
	public GameObject fireZombie;
	public float speed = 10f;
	int count=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int rand = Random.Range (1, 1000);
		if (rand > 990 ) {
			var tempZombie = (GameObject)Instantiate (fireZombie, new Vector3 (0f, 3f, 0f), Quaternion.identity);
			count++;
				}

	}
}
