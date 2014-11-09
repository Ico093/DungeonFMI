using UnityEngine;
using System.Collections;

public class bossScr : MonoBehaviour {

	public static float hp = 1000;
	public GameObject projectile;

	float dir = 0;
	float alarm = 0.0f;
	public float maxAlarm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		alarm -= Time.deltaTime;
		if (alarm <= 0) 
		{
			Shoot (dir, 5);
			alarm = maxAlarm;
		}
		dir++;
		//Vector2 dirVec = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));

	}

	void Shoot(float angle,float speed)
	{
		Vector2 tempDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		if (angle != 0.0f)
		{
			
			float rad = (angle * Mathf.PI) / 180;
			Matrix4x4 rotMatrix = new Matrix4x4();
			rotMatrix.SetRow(0, new Vector4(Mathf.Cos (rad), -Mathf.Sin (rad), 0 ,0));
			rotMatrix.SetRow(1, new Vector4(Mathf.Sin (rad), Mathf.Cos (rad), 0 ,0));
			rotMatrix.SetRow(2, new Vector4(0, 0, 1 ,0));
			rotMatrix.SetRow(3, new Vector4(0, 0, 0 ,1));
			tempDirection = rotMatrix * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
			
		}
		var tempProjectile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		var projectileHelper = tempProjectile.GetComponent<EnemyProjectile> ();
		projectileHelper.SetTargetPosition (tempDirection.normalized);
		projectileHelper.Rotate (angle);
		projectileHelper.SetDamage (10);
		projectileHelper.setSpeed (5);
	}
}
