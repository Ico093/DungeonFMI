using UnityEngine;
using System.Collections;

public class createArenaEnemy : MonoBehaviour {

	public GameObject zombie;
	public GameObject fireZombie;
	GameObject player;
	int count=0;
	float spawnAlarm = 3;
	float maxSpawnAlarm = 10;

	public float radius;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		spawnAlarm -= Time.deltaTime;
		if (spawnAlarm <= 0) 
		{
			SpawnZombie();
			spawnAlarm = maxSpawnAlarm;
		}
	}

	void SpawnZombie()
	{
		Vector3 zobmiePos = Random.onUnitSphere * radius;
		var tempZombie = (GameObject)Instantiate (Random.Range (1, 10) > 5 ? fireZombie : zombie, zobmiePos , Quaternion.identity);
	}
}