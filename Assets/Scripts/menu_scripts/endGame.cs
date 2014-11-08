using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour
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
				int maxGroupWidth = Screen.width / 2;
				int maxGroupHeight = Screen.height - 100;
	
				GUIStyle endGameStyle = GUI.skin.GetStyle ("label");
				endGameStyle.fontSize = 40;
				endGameStyle.fontStyle = FontStyle.Bold;
				endGameStyle.alignment = TextAnchor.MiddleCenter;

				GUIStyle scoreStyle = GUI.skin.GetStyle ("label");
				scoreStyle.fontSize = 40;
				scoreStyle.fontStyle = FontStyle.Bold;
				scoreStyle.alignment = TextAnchor.LowerCenter;
	
				GUIStyle buttonStyle = GUI.skin.GetStyle ("button");
				buttonStyle.fontSize = 20;
				buttonStyle.alignment = TextAnchor.MiddleCenter;
	
				// Make a group on the center of the screen
		GUI.BeginGroup (new Rect (maxGroupWidth - maxGroupWidth / 2, 50, maxGroupWidth, maxGroupHeight));
	
		GUI.Box (new Rect (0, 0, maxGroupWidth, maxGroupHeight/4), "Game Over", endGameStyle);
		GUI.Box (new Rect (0,maxGroupHeight/4, maxGroupWidth, maxGroupHeight/4), "Score: " + dungeonPlayerScr.score, scoreStyle);
		if (GUI.Button (new Rect (25, maxGroupHeight / 5 * 3, maxGroupWidth - 50, maxGroupHeight / 6), "To Main Menu", buttonStyle)) {
						if (Event.current.button == 0) {
								Application.LoadLevel ("MainMenu");
						}
				}
				GUI.EndGroup ();
		}
}
