using UnityEngine;
using System.Collections;

public class ConstructBG : MonoBehaviour {
	public GameObject brick1;
	public GameObject brick2;
	public GameObject brick3;
	public GameObject brick4;
	public GameObject brick5;
	public GameObject brick6;
	GameObject[] bricks = new GameObject[6];
	public Vector2 start;
	public Vector2 size;
	private int count;


	// Use this for initialization
	void Start () {
		bricks [0] = brick1;
		bricks [1] = brick2;
		bricks [2] = brick3;
		bricks [3] = brick4;
		bricks [4] = brick5;
		bricks [5] = brick6;

		count = 0;
		for (int i=0; i<5; i++)
						for (int j=0; j<3; j++)
								if (Random.Range (1, 10) > 2) {
				int brick = Random.Range(0, 6);
										Instantiate (bricks[brick], new Vector3 (i * size.x + start.x, j * size.y + start.y, 0), Quaternion.identity);
										count++;
								}
	}
		
	// Update is called once per frame
	void Update () {
		if (count == 0) {
			Debug.Log ("You Win");
			GlobalPlayer._value = padMove._value;
			GlobalPlayer._score += padMove._score;
			Application.LoadLevel ("OutdoorScene");
				}


	
	}
	public void DestroyedBrick() {
				count--;
		}
}
