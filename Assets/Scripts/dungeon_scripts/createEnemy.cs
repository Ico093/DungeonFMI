using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour {

	public GameObject zombie;
	public GameObject fireZombie;
	GameObject player;
	public GameObject floor;
	public float speed = 10f;
	int count=0;
	float timeSpawn=3;
	float CurrentTimeSpawn=3;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentTimeSpawn <= 0) {
					Vector3 tempZombieVector = new Vector3 (Random.Range (-29, -24), player.transform.position.y + 10, 0f);
			var tempZombie = (GameObject)Instantiate (Random.Range(1,3)>1 ? zombie : fireZombie, tempZombieVector, Quaternion.identity);
						count++;
				CurrentTimeSpawn=timeSpawn;
			timeSpawn -= 1f/ 100f;
				}

		CurrentTimeSpawn -= Time.deltaTime;

				

	}
}