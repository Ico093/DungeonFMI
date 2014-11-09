using UnityEngine;
using System.Collections;

public class hpBarScr : MonoBehaviour {

	public Transform playerTransform;
	public arenaPlayerScr player;
	public SpriteRenderer player_render;

	float spriteWidth;
	float spriteHeight;	

	// Use this for initialization
	void Start () {
		//playerTransform = player.GetComponent<Transform> ();
		spriteWidth = player_render.bounds.size.x;
		spriteHeight = player_render.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y + spriteHeight/(1.5f), 0);
		int r = 255-(int)(((float)player.GetHp () / (float)player.GETMAXHP ())*255);
		int g = 0+(int)(((float)player.GetHp () / (float)player.GETMAXHP ())*255);
		int b = 0;
		int a = 255;
		this.GetComponent<SpriteRenderer>().color= new Color (r/255.0F,g/255.0F,b/255.0F,a/255.0F);


	}
}
