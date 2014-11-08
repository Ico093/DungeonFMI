using UnityEngine;
using System.Collections;

public class fireZombie : MonoBehaviour {

	public float chaseSpeed = 2.0f;                           // The nav mesh agent's speed when chasing.

	// Reference to the last global sighting of the player.
	public GameObject projectile;
	public GameObject player;

	public int hp;
	public int dmg;
	float attackSpeed;
	float attackSpeedCD;

	Vector2 direction = new Vector2(0, 1);

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
		//animator = this.GetComponent<Animator> ();
		//animator.speed = 0.5f;
		player = GameObject.Find ("player");
		SetDamage (10);
		SetAS (2.0f);
		attackSpeedCD = attackSpeed;
	}
	
	void Update ()
	{	
		attackSpeed -= Time.deltaTime;
		if (attackSpeed <= 0)
			{
				Shoot (Random.Range (-30,30));
				attackSpeed=attackSpeedCD;
			}
		Vector3 player_position = player.transform.position;
		Vector3 tempVector = new Vector3 (transform.position.x, transform.position.y, 0f);
		tempVector -= ((tempVector - player_position).normalized * chaseSpeed * Time.deltaTime);
		transform.position = tempVector;
		double moveHorizontal = (player_position - transform.position).normalized.x;
		double moveVertical = (player_position - transform.position).normalized.y;
		if (moveHorizontal == 0 && moveVertical > 0) {	// up
			//sr.sprite = states[3];
			direction.x = 0;
			direction.y = 1;
		} else if (moveHorizontal == 0 && moveVertical < 0) {	//down
			direction.x = 0;
			direction.y = -1;
			//animator.SetInteger("Direction", 2);
		} else if (moveHorizontal > 0 && moveVertical == 0) {	//right
			direction.x = 1;
			direction.y = 0;
			//animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical == 0) {	//left
			direction.x = -1;
			direction.y = 0;

			//animator.SetInteger("Direction", 1);
		} else if (moveHorizontal > 0 && moveVertical > 0) {	//up right
			direction.x = 1;
			direction.y = 1;
			//animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical > 0) {	//up left
			direction.x = -1;
			direction.y = 1;
			//animator.SetInteger("Direction", 1);
		} else if (moveHorizontal > 0 && moveVertical < 0) {	//down right
			direction.x = 1;
			direction.y = -1;
			//animator.SetInteger("Direction", 3);
		} else if (moveHorizontal < 0 && moveVertical < 0) {	//down left
			direction.x = -1;
			direction.y = -1;
			//animator.SetInteger("Direction", 2);
		} else {
		}
	}

	void Shoot(float angle)
	{
		Vector2 tempDirection = direction;
		if (angle != 0.0f)
		{
			float rad = (angle * Mathf.PI) / 180;
			Matrix4x4 rotMatrix = new Matrix4x4();
			rotMatrix.SetRow(0, new Vector4(Mathf.Cos (rad), -Mathf.Sin (rad), 0 ,0));
			rotMatrix.SetRow(1, new Vector4(Mathf.Sin (rad), Mathf.Cos (rad), 0 ,0));
			rotMatrix.SetRow(2, new Vector4(0, 0, 1 ,0));
			rotMatrix.SetRow(3, new Vector4(0, 0, 0 ,1));
			tempDirection = rotMatrix * direction;

		}
		var tempProjectile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		var projectileHelper = tempProjectile.GetComponent<EnemyProjectile> ();
		projectileHelper.SetTargetPosition (tempDirection.normalized);
		projectileHelper.SetDamage (dmg);
	}

	public void TakeHit(int damage)
	{
		hp -= damage;
		if (hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}
