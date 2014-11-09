using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour {

	public GameObject zombie;
	public GameObject fireZombie;
	GameObject player;
	public GameObject floor;
	public float speed = 10f;
	int count=0;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		int rand = Random.Range (1, 1000);
		if (rand > 990 ) {
			Vector3 tempZombieVector=new Vector3 (player.transform.position.x+Random.Range(-2,2), player.transform.position.y+Random.Range(1,floor.renderer.bounds.size.y)/2, 0f);
			var tempZombie = (GameObject)Instantiate (Random.Range (1, 10) > 5 ? fireZombie : zombie,tempZombieVector , Quaternion.identity);
			count++;
				}

	}
}