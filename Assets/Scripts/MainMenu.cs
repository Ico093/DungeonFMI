﻿using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				// Make a group on the center of the screen
				GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
				// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
		
				// We'll make a box so you can see where the group is on-screen.
				GUI.Box (new Rect (0, 0, 200, 200), "Dungeon FMI");

				if (GUI.Button (new Rect (60, 40, 80, 30), "Play")) {
						if (Event.current.button == 0) {
								Application.LoadLevel ("OutdoorScene");
						}
				}

				if (GUI.Button (new Rect (60, 80, 80, 30), "How to play")) {
						if (Event.current.button == 0) {

						}
				}

				if (GUI.Button (new Rect (60, 120, 80, 30), "Exit")) {
						if (Event.current.button == 0) {
				
						}
				}

				// End the group we started above. This is very important to remember!
				GUI.EndGroup ();
		}
}
