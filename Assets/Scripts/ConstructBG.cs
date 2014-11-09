using UnityEngine;
using System.Collections;

public class ConstructBG : MonoBehaviour {
	public GameObject brick1;
	public GameObject brick2;
	public GameObject brick3;
	public GameObject brick4;
	public GameObject brick5;
	public GameObject brick6;
	public Vector2 start;
	public Vector2 size;
	private int count;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 6; i++) {
			
				}

		count = 0;
		for (int i=0; i<5; i++)
						for (int j=0; j<3; j++)
								if (Random.Range (1, 10) > 2) {

										Instantiate (brick, new Vector3 (i * size.x + start.x, j * size.y + start.y, 0), Quaternion.identity);
										count++;
								}
	}
		
	// Update is called once per frame
	void Update () {
		if (count == 0)
						Debug.Log ("You Win");
	
	}
	public void DestroyedBrick() {
				count--;
		}
}
