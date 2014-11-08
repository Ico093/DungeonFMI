using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public float chaseSpeed = 0.002f;                           // The nav mesh agent's speed when chasing.

	public GameObject player;    // Reference to the last global sighting of the player.

	
	void Start () {
		player=GameObject.Find("player");
		}
	
	void Update ()
	{
		
		Vector3 player_position=player.transform.position;
		transform.position -= ((transform.position - player_position).normalized * chaseSpeed * Time.deltaTime);
	
	}


	

}
