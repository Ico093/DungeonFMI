using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{

	public Texture backgroundImage;
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
				
		int maxGroupWidth = Screen.width / 6;
				int maxroupHeight = Screen.height - 100;

				GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), backgroundImage);

				GUIStyle logoStyle = GUI.skin.GetStyle ("label");
				logoStyle.fontSize = 40;
				logoStyle.fontStyle = FontStyle.Bold;
				logoStyle.alignment = TextAnchor.UpperCenter;

				GUIStyle buttonStyle = GUI.skin.GetStyle ("button");
				buttonStyle.fontSize = 20;
				buttonStyle.alignment = TextAnchor.MiddleCenter;

				// Make a group on the center of the screen
				GUI.BeginGroup (new Rect (maxGroupWidth - maxGroupWidth / 2, 50, maxGroupWidth, maxroupHeight));

				//GUI.Box (new Rect (0, 0, maxGroupWidth, maxroupHeight), "Dungeon FMI", logoStyle);

				if (GUI.Button (new Rect (25, maxroupHeight / 5 * 2, maxGroupWidth - 50, maxroupHeight / 6), "Play", buttonStyle)) {
						if (Event.current.button == 0) {
								Application.LoadLevel ("OutdoorScene");
						}
				}


				if (GUI.Button (new Rect (25, maxroupHeight / 5 * 4, maxGroupWidth - 50, maxroupHeight / 6), "Exit", buttonStyle)) {
						if (Event.current.button == 0) {
								Application.Quit ();
						}
				}

				// End the group we started above. This is very important to remember!
				GUI.EndGroup ();
		}
}
