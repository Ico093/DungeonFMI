using UnityEngine;
using System.Collections;

public class cameraScr : MonoBehaviour 
{
	public float leftBoundary;
	public float rightBoundary;
	public float topBoundary;
	public float bottomBoundary;

	public GameObject player;
	
	void Start () 
	{
		Vector3 newPosition = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		float newX = Mathf.Clamp (player.transform.position.x, leftBoundary, rightBoundary);
		float newY = Mathf.Clamp (player.transform.position.y, bottomBoundary, topBoundary);
		Vector3 newPosition = new Vector3 (newX, newY, -10);
		transform.position = newPosition;
	}
}
