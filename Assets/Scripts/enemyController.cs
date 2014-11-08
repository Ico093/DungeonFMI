using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	SpriteRenderer sr;

	public float chaseSpeed = 0.002f;                           // The nav mesh agent's speed when chasing.

	public GameObject player;    // Reference to the last global sighting of the player.
	public Sprite[] states;
		
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		player = GameObject.Find("player");
		states = Resources.LoadAll<Sprite>("zombie1");
	}
	
	void Update ()
	{	
		Vector3 player_position = player.transform.position;
		transform.position -= ((transform.position - player_position).normalized * chaseSpeed * Time.deltaTime);
		double moveHorizontal = (transform.position - player_position).normalized.x;
		double moveVertical = (transform.position - player_position).normalized.y;
		if (moveHorizontal == 0 && moveVertical > 0) {
			sr.sprite = states[3];
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			sr.sprite = states[2];
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			sr.sprite = states[5];
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			sr.sprite = states[1];
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			sr.sprite = states[4];
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			sr.sprite = states[2];
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			sr.sprite = states[6];
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			sr.sprite = states[0];
		} else { 
		}
	}


	

}
