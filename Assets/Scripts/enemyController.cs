using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public float chaseSpeed = 2.0f;                           // The nav mesh agent's speed when chasing.

	public GameObject player;    // Reference to the last global sighting of the player.

	public int hp;
	int dmg;
	float attackSpeed;
	float attackSpeedCD;

	Animator animator;

	public void SetDamage(int damage)
	{
		dmg = damage;
		}

	public int GetDamage()
	{
		return dmg;
	}

	public void SetHP(int healthp)
	{
		hp = healthp;
		}

	public int GetHP()
	{
		return hp;
	}

	public void SetAS(float attackS)
	{
		attackSpeed = attackS;
	}

	public float GetAS()
	{
		return attackSpeed;
		}

	public float GetASCD()
	{
		return attackSpeedCD;
	}
		
	void Start () {
		player = GameObject.Find("player");
		animator = this.GetComponent<Animator> ();
		animator.speed = 0.5f;
		SetDamage (10);
		SetAS (3.0f);
		attackSpeedCD = attackSpeed;
	}
	
	void Update ()
	{	
		attackSpeed -= Time.deltaTime;
		Vector3 player_position = player.transform.position;
		Vector3 tempVector = new Vector3 (transform.position.x, transform.position.y, 0f);
		tempVector -= ((tempVector - player_position).normalized * chaseSpeed * Time.deltaTime);
		transform.position = tempVector;
		double moveHorizontal = (player_position - transform.position).normalized.x;
		double moveVertical = (player_position - transform.position).normalized.y;
		if (moveHorizontal == 0 && moveVertical > 0) {	// up
			//sr.sprite = states[3];
		} else if (moveHorizontal == 0 && moveVertical < 0) {	//down
			animator.SetInteger("Direction", 2);
		} else if (moveHorizontal > 0 && moveVertical == 0) {	//right
			animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical == 0) {	//left
			animator.SetInteger("Direction", 1);
		} else if (moveHorizontal > 0 && moveVertical > 0) {	//up right
			animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical > 0) {	//up left
			animator.SetInteger("Direction", 1);
		} else if (moveHorizontal > 0 && moveVertical < 0) {	//down right
			animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical < 0) {	//down left
			animator.SetInteger("Direction", 2);
		} else {
		}
	}

	public void TakeHit(int damage)
	{
		hp -= damage;
		if (hp <= 0) {
			Destroy (this.gameObject);
				}
	}
	

}
