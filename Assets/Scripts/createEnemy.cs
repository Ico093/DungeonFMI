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
			var tempZombie = (GameObject)Instantiate (Random.Range (1, 10) > 5 ? fireZombie : zombie, new Vector3 (Random.Range (1, 15), 6f, 0f), Quaternion.identity);
			count++;
				}

	}
}
