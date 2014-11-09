using UnityEngine;
using System.Collections;

public class onDead : MonoBehaviour {

	public GameObject coin;
	public Sprite health;
	public Sprite dmg;
	public Sprite weapon;
	public Sprite router;
	public float timeLeft;
	// Use this for initialization
	void Start () {
		timeLeft = Random.Range (3, 5);
	}
	public void setCoin(Sprite[] sprites) {
		int random = Random.Range (1, 10);
		if (random > 8) {
			var tempCoin = Instantiate (coin, this.transform.position, Quaternion.identity) as GameObject;
						var tempCoinHelper = tempCoin.GetComponent<dropScr> ();
						int rand = Random.Range (1, 4);
						if (rand == 1) {
								tempCoinHelper.SetType ("health");
								tempCoinHelper.SetValue (20);
								tempCoinHelper.SetScore (20);
				tempCoinHelper.SetSprite(sprites[0]);
			} else if (rand == 2) {
								tempCoinHelper.SetType ("weapon");
								tempCoinHelper.SetValue (1);
								tempCoinHelper.SetScore (45);
				tempCoinHelper.SetSprite(sprites[1]);
			} else if (rand == 3) {
								tempCoinHelper.SetType ("dmg");
								tempCoinHelper.SetValue (5);
								tempCoinHelper.SetValue (50);
				tempCoinHelper.SetSprite(sprites[2]);
			} else
								Debug.Log ("1111");
				} else if (random > 1) {
			var tempCoin = Instantiate (coin, this.transform.position, Quaternion.identity) as GameObject;
					var tempCoinHelper = tempCoin.GetComponent<dropScr> ();
			tempCoinHelper.SetType ("router");
			tempCoinHelper.SetScore (80);
			tempCoinHelper.SetSprite(sprites[3]);


				}
		timeLeft = 1.5f;
	}
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0)
		{
			Destroy (this.gameObject);
		}
	}
}
