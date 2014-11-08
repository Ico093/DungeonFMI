using UnityEngine;
using System.Collections;

public class dungeonPlayerScr : MonoBehaviour {
	
	public float movementSpeed;
	public GameObject projectile;
	float projectileTimer = 0.2f;
	float projectileTimerMAX = 0.2f;
	int mode = 3;
	public int hp;
	public int maxHP;
	int dmg;
	
	float moveHorizontal;
	float moveVertical;
	Vector2 direction = new Vector2(0, 1);

	SpriteRenderer sr;
	public Sprite[] states;

	public void SetMode(int m)
	{
		mode = m;
	}

	public void SetHp(int healthp)
	{
		hp = healthp;
	}
	
	public int GetHp()
	{
		return hp;
	}
	
	public void SetDamage(int damage)
	{
		dmg = damage;
	}
	
	public int GetDamage()
	{
		return dmg;
	}

	public int GETMAXHP()
	{
		return maxHP;
	}
	
	void Start () 
	{
		SetDamage (5);
		sr = GetComponent<SpriteRenderer>();
		states = Resources.LoadAll<Sprite>("brain");
	}
	
	void Update () 
	{
		PlayerMovement ();
		ShootLogic ();
	}
	
	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		transform.Translate (new Vector3(moveHorizontal, moveVertical, 0).normalized * movementSpeed * Time.deltaTime);
		SetDirection ();
	}
	
	void ShootLogic()
	{
		projectileTimer -= Time.deltaTime;
		if (projectileTimer <= 0 && Input.GetKeyDown(KeyCode.Space)) {
			ShootMode (mode);
			projectileTimer = projectileTimerMAX;
		}
	}

	void ShootMode(int mode)
	{
		switch (mode) 
		{
		case 1:
			Shoot (0f);
			break;
		case 2:
			Shoot (-15f);
			Shoot (15f);
			break;
		case 3:
			Shoot (0f);
			Shoot (-15f);
			Shoot (15f);
			break;
		default:
			Shoot (0f);
			break;
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
		var projectileHelper = tempProjectile.GetComponent<projectileControllerScr> ();
		projectileHelper.SetTargetPosition (tempDirection.normalized);
		projectileHelper.SetDamage (5);
	}

	void SetDirection()
	{
		if (moveHorizontal == 0 && moveVertical > 0) {
			direction.x = 0;
			direction.y = 1;
			sr.sprite = states[3];
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			direction.x = 0;
			direction.y = -1;
			sr.sprite = states[7];
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			direction.x = 1;
			direction.y = 0;
			sr.sprite = states[5];
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			direction.x = -1;
			direction.y = 0;
			sr.sprite = states[1];
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			direction.x = 1;
			direction.y = 1;
			sr.sprite = states[4];
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			direction.x = -1;
			direction.y = 1;
			sr.sprite = states[2];
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			direction.x = 1;
			direction.y = -1;
			sr.sprite = states[6];
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			direction.x = -1;
			direction.y = -1;
			sr.sprite = states[0];
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "BasicZombie") {
			var another = other.gameObject.GetComponent<enemyController> ();
			if(another.GetAS () <= 0.0f)
			{
				this.TakeHit(another.GetDamage());
				another.SetAS(another.GetASCD());
			}
				}

	}

	public void TakeHit(int damage)
	{
		hp -= damage;
		if (hp <= 0) {
			Debug.Log ("YOU DEAD MOTHERFUCKER!!!!");
				}
	}
}
