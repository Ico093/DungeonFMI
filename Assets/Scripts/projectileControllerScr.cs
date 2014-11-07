using UnityEngine;
using System.Collections;

public class projectileControllerScr : MonoBehaviour {

	public float projectileSpeed;

	Vector2 projectileStartPosition;
	Vector2 projectileTargetPosition;

	Vector2 projectileDirection = new Vector2(1, 1);

	// Use this for initialization
	//void Start (Vector3 position) {
	//	projectileStartPosition = position;
	//}
	
	// Update is called once per frame
	void Update () {
		//transform.position += projectileDirection * projectileSpeed * Time.deltaTime;
		//		if(transform.position - 
		//projectile position update
		//if projectile is further than camera sees  - Destroy
	}

	public void SetTargetPosition(Vector2 target)
	{
		Matrix4x4 matrix = new Matrix4x4 ();
		matrix.SetRow (0, new Vector4 (target.x, 0, 0, 0));
		matrix.SetRow (1, new Vector4 (0, target.y, 0, 0));
		matrix.SetRow (2, new Vector4 (0, 0, 1, 0));
		matrix.SetRow (3, new Vector4 (0, 0, 0, 1));
		Vector2 tempVector = matrix.MultiplyVector (new Vector4 (projectileDirection.x, projectileDirection.y, 0, 0));
		projectileTargetPosition = projectileStartPosition + tempVector;
		projectileDirection = projectileTargetPosition - projectileStartPosition;
		projectileDirection.Normalize ();
	}
}
