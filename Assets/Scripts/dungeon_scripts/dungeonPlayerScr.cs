using UnityEngine;
using System.Collections;

public class dungeonPlayerScr : MonoBehaviour {
	
	public float movementSpeed;
	public GameObject projectile;
	public GameObject endScreen;

	float projectileTimer = 0.2f;
	float projectileTimerMAX = 0.2f;
	float projectileAngle = -90.0f;
	int mode = 3;
	public int hp;
	public int maxHP;
	public float dieTimeInHole;
	int dmg;
	public static long score;
	
	float moveHorizontal;
	float moveVertical;
	Vector2 direction = new Vector2(0, 1);

	SpriteRenderer sr;
	public Sprite[] states;
	public Sprite dead_sprite;


	//Styles
	public Texture2D boxBackground;
	public Texture2D router;

	void OnGUI() {
		GUIStyle boxStyle=GUI.skin.GetStyle("box");
		boxStyle.fontSize = 30;
		boxStyle.alignment = TextAnchor.MiddleCenter;
		boxStyle.normal.background = boxBackground;

		int maxGroupWidth = Screen.width;
		int maxGroupHeight = Screen.height / 8;
		GUI.BeginGroup (new Rect (0, maxGroupHeight * 7, maxGroupWidth, maxGroupHeight));

		int singleWidth = maxGroupWidth / 3;

		GUI.Box(new Rect(0,0,singleWidth,maxGroupHeight),"Health: " + GetHp ().ToString(),boxStyle);


		GUI.Box(new Rect(singleWidth,0,singleWidth,maxGroupHeight),new GUIContent("x100",router),boxStyle);
		GUI.Box(new Rect(singleWidth*2,0,singleWidth,maxGroupHeight),"Score: " + getScore().ToString(),boxStyle);


		GUI.EndGroup ();
		}

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
	public long getScore() {
				return score;
	}
	public void addScore(long _score) {
		score+=_score;
	}

	void Start () 
	{
		SetDamage (5);
		sr = GetComponent<SpriteRenderer>();
		states = Resources.LoadAll<Sprite>("brain");
		score = 0;
	}
	
	void FixedUpdate () 
	{
						PlayerMovement ();
						ShootLogic ();

				
	}
	
	void PlayerMovement()
	{
		moveHorizontal = Input.GetAxis ("Horizontal") ;
		moveVertical = Input.GetAxis ("Vertical") ;
		if(moveVertical>0){
			Vector3 EndStageVector=endScreen.transform.position;

			EndStageVector.y=this.transform.position.y-endScreen.collider2D.bounds.size.y/2-3;
			Debug.Log(EndStageVector.y);
			Debug.Log("aaa");
			endScreen.transform.position=EndStageVector;
		}
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
		for (int i=mode; i>0; i-=2) {
			if(i>1) {
				float angle=i*5f;
				Shoot (angle);
				Shoot (-angle);
			}
			if (i==1) {
				Shoot (0f);
			}
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
		projectileHelper.Rotate (projectileAngle);
		projectileHelper.SetDamage (5);
	}

	void SetDirection()
	{
		if (moveHorizontal == 0 && moveVertical > 0) {
			direction.x = 0;
			direction.y = 1;
			projectileAngle = 0.0f;
			sr.sprite = states[3];
		} else if (moveHorizontal == 0 && moveVertical < 0) {
			direction.x = 0;
			direction.y = -1;
			projectileAngle = -180.0f;
			sr.sprite = states[7];
		} else if (moveHorizontal > 0 && moveVertical == 0) {
			direction.x = 1;
			direction.y = 0;
			projectileAngle = -90.0f;
			sr.sprite = states[5];
		} else if (moveHorizontal < 0 && moveVertical == 0) {
			direction.x = -1;
			direction.y = 0;
			projectileAngle = 90.0f;
			sr.sprite = states[1];
		} else if (moveHorizontal > 0 && moveVertical > 0) {
			direction.x = 1;
			direction.y = 1;
			projectileAngle = -45.0f;
			sr.sprite = states[4];
		} else if (moveHorizontal < 0 && moveVertical > 0) {
			direction.x = -1;
			direction.y = 1;
			projectileAngle = 45.0f;
			sr.sprite = states[2];
		} else if (moveHorizontal > 0 && moveVertical < 0) {
			direction.x = 1;
			direction.y = -1;
			projectileAngle = -135.0f;
			sr.sprite = states[6];
		} else if (moveHorizontal < 0 && moveVertical < 0) {
			direction.x = -1;
			direction.y = -1;
			projectileAngle = 135.0f;
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
		else if (other.gameObject.tag == "OtherZombie") {
			var another = other.gameObject.GetComponent<fireZombie> ();
			if(another.GetAS () <= 0.0f)
			{
				this.TakeHit(another.GetDamage());
				another.SetAS(another.GetASCD());
			}
		}

		if (other.gameObject.tag == "enemyProjectile") {
			var another = other.gameObject.GetComponent<EnemyProjectile> ();
			TakeHit(another.GetDamage());
			Destroy(other.gameObject);
			
		}


	}

	public void TakeHit(int damage)
	{
		hp -= damage;
		if (hp <= 0) {
			Debug.Log ("YOU DEAD MOTHERFUCKER!!!! score:"+score);

			Application.LoadLevel ("EndGame");

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "powerUp") {
			
			var another = other.GetComponent<dropScr> ();
			
			
			string type=another.getType();
			int value=another.GetValue();
			int _score=another.GetScore();
			
			addScore(_score);
			Destroy(another.gameObject);
			Debug.Log(type);
			switch(type) {
			case "damage":
				SetDamage((GetDamage()+value));
				break;
			case "weapon":
				if(mode<9)mode+=value;
				break;
			case "health":
				if(GetHp()+value<= GETMAXHP())SetHp(GetHp()+value);
				break;
			default:break;
				
			}
			
			
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
				if (other.gameObject.tag == "hole") {
					sr.sprite = dead_sprite;
					Application.LoadLevel ("EndGame");
				
						

		
				}
		}
}
