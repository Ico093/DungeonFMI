using UnityEngine;
using System.Collections;

public class exetendpath : MonoBehaviour {

	public GameObject player;
	public GameObject hole1 = null;
	public GameObject hole2 = null;
	void FixedUpdate()
	{

		float widthOfObject = renderer.bounds.size.y*3;
		Vector3 pos = transform.position;
		if (player.transform.position.y > pos.y+(renderer.bounds.size.y)) {
						pos.y += widthOfObject;
						transform.position = pos;
						Vector3 vector=new Vector3(Random.Range(1,renderer.bounds.size.x)-renderer.bounds.size.x/2,Random.Range(10,renderer.bounds.size.y)+renderer.bounds.size.y/2,0);
						if(this.gameObject.tag=="tiles")Instantiate (hole1, transform.position-vector ,Quaternion.identity);
				}
	}
}
