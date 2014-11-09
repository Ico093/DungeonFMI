using UnityEngine;
using System.Collections;

public class fireZombie : MonoBehaviour {

	public float chaseSpeed = 2.0f;                           // The nav mesh agent's speed when chasing.

	// Reference to the last global sighting of the player.
	public GameObject projectile;
	public GameObject player;
	
	public Sprite[] sprites=new Sprite[4];
	public GameObject corpse;
	public int score;
	public int hp;
	public int dmg;
	float attackSpeed;
	float attackSpeedCD;
	float rotAngle = -90.0f;

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
		animator = this.GetComponent<Animator> ();
		animator.speed = 0.5f;
		player = GameObject.Find ("player");
		SetDamage (10);
		SetAS (1f);
		score = 100;
		attackSpeedCD = attackSpeed;
	}
	
	void Update ()
	{	
		attackSpeed -= Time.deltaTime;
		if (attackSpeed <= 0)
			{
			int shoot_times=Random.Range (1,3);
			for(int i=0;i<shoot_times;i++)
				Shoot (0,Random.Range(1,4));
			attackSpeed=attackSpeedCD;
			}
		Vector3 player_position = player.transform.position;
		Vector3 tempVector = new Vector3 (transform.position.x, transform.position.y, 0f);
		tempVector -= ((tempVector - player_position).normalized * chaseSpeed * Time.deltaTime);
		transform.position = tempVector;
		float moveHorizontal = (player_position - transform.position).normalized.x;
		float moveVertical = (player_position - transform.position).normalized.y;
		if (moveHorizontal == 0 && moveVertical > 0) {	// up
			animator.SetInteger("Direction", 0);
			rotAngle = 0.0f;
		} else if (moveHorizontal == 0 && moveVertical < 0) {	//down
			animator.SetInteger("Direction", 2);
			rotAngle = -180.0f;
		} else if (moveHorizontal > 0 && moveVertical == 0) {	//right
			animator.SetInteger("Direction", 3);
			rotAngle = -90.0f;
		} else if (moveHorizontal < 0 && moveVertical == 0) {	//left
			animator.SetInteger("Direction", 1);
			rotAngle = 90.0f;
		} else if (moveHorizontal > 0 && moveVertical > 0) {	//up right
			animator.SetInteger("Direction", 0);
			rotAngle = -45.0f;
		} else if (moveHorizontal < 0 && moveVertical > 0) {	//up left
			animator.SetInteger("Direction", 1);
			rotAngle = 45.0f;
		} else if (moveHorizontal > 0 && moveVertical < 0) {	//down right
			animator.SetInteger("Direction", 3);
			rotAngle = -135.0f;
		} else if (moveHorizontal < 0 && moveVertical < 0) {	//down left
			animator.SetInteger("Direction", 2);
			rotAngle = 135.0f;
		}


		direction.x = moveHorizontal;
		direction.y = moveVertical;
	}

	void Shoot(float angle,float speed)
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
		projectileHelper.Rotate (rotAngle);
		projectileHelper.SetDamage (dmg);
		projectileHelper.setSpeed (speed);
	}

	public void TakeHit(int damage)
	{
		hp -= damage;
		if (hp <= 0) {
			player.gameObject.GetComponent<dungeonPlayerScr>().addScore(score);
			var tempCorpse = Instantiate(corpse, transform.position, Quaternion.identity) as GameObject;
			var CheckForCoin = tempCorpse.GetComponent<onDead> ();
			GameObject _player=GameObject.Find("player");
			_player.GetComponent<dungeonPlayerScr>().addKill();
			CheckForCoin.setCoin(sprites);
			Destroy (this.gameObject);
		}
	}
}
