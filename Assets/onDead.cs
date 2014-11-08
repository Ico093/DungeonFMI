using UnityEngine;
using System.Collections;

public class onDead : MonoBehaviour {

	public GameObject coin;
	public float timeLeft;
	// Use this for initialization
	void Start () {
		if (Random.Range (1, 100) > 50) {
			var tempCoin = Instantiate(coin, this.transform.position, Quaternion.identity);
				}
		timeLeft = Random.Range (3, 5);
	}
	public void setCoin() {

		if (Random.Range (1, 100) > 50) {
			var tempCoin = Instantiate(coin, this.transform.position, Quaternion.identity) as GameObject;
			var tempCoinHelper = tempCoin.GetComponent<dropScr>();
			int rand=Random.Range(1,3);
			Debug.Log(rand);
			if(rand==1) {
				tempCoinHelper.SetType("health");
				tempCoinHelper.SetValue(20);
			}
			if(rand==2) {
				tempCoinHelper.SetType("weapon");
				tempCoinHelper.SetValue(1);
			}
			if(rand==3) {
				tempCoinHelper.SetType("dmg");
				tempCoinHelper.SetValue(5);
			}

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
