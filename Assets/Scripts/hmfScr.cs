﻿using UnityEngine;
using System.Collections;

public class hmfScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Application.LoadLevel("Labyrinth");
		}
	}
}
