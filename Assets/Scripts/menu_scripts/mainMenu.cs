using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{
		//Styles
		public Texture backgroundImage;
		public Texture2D buttonPlay;
		public Texture2D buttonExit;
		public Texture2D buttonBackground;

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
				GUI.backgroundColor = Color.clear;
				int maxGroupWidth = Screen.width / 5;
				int maxGroupHeight = Screen.height - 100;

				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundImage);

				GUIStyle logoStyle = GUI.skin.GetStyle ("label");
				logoStyle.fontSize = 40;
				logoStyle.fontStyle = FontStyle.Bold;
				logoStyle.alignment = TextAnchor.UpperCenter;
				

				// Make a group on the center of the screen
				GUI.BeginGroup (new Rect (0, 50, Screen.width, Screen.height));




		if (GUI.Button (new Rect (maxGroupWidth * 2 - Screen.width / 10, maxGroupHeight - maxGroupHeight / 6, maxGroupWidth, maxGroupHeight / 6),buttonExit)) {
						if (Event.current.button == 0) {
								Application.Quit ();
						}
				}

		if (GUI.Button (new Rect (maxGroupWidth * 3 - Screen.width / 13, maxGroupHeight - maxGroupHeight / 6, maxGroupWidth, maxGroupHeight / 6), buttonPlay)) {
						if (Event.current.button == 0) {
								Application.LoadLevel ("OutdoorScene");
						}
				}


				// End the group we started above. This is very important to remember!
				GUI.EndGroup ();
		}
}
