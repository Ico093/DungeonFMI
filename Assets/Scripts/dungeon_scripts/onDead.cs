using UnityEngine;
using System.Collections;

public class onDead : MonoBehaviour {

	public GameObject coin;
	public float timeLeft;
	// Use this for initialization
	void Start () {

		timeLeft = Random.Range (3, 5);
	}
	public void setCoin() {

		if (Random.Range (1, 100) > 9) {
			var tempCoin = Instantiate(coin, this.transform.position, Quaternion.identity) as GameObject;
			var tempCoinHelper = tempCoin.GetComponent<dropScr>();
			int rand=Random.Range(1,4);
			if(rand==1) {
				tempCoinHelper.SetType("health");
				tempCoinHelper.SetValue(20);
				tempCoinHelper.SetScore(20);
			}
			else if(rand==2) {
				tempCoinHelper.SetType("weapon");
				tempCoinHelper.SetValue(1);
				tempCoinHelper.SetScore(45);
			}
			else if(rand==3) {
				tempCoinHelper.SetType("dmg");
				tempCoinHelper.SetValue(5);
				tempCoinHelper.SetValue(50);
			}
			else Debug.Log ("1111");
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
