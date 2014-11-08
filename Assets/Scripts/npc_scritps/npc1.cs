using UnityEngine;
using System.Collections.Generic;

public class npc1 : MonoBehaviour
{
		public bool isDialogOpen = false;
		public List<string> dialog ;
		public Texture player;
		public Texture npc;
		public int dialogCounter = 0;
		public Texture2D dialogBackground;
		// Use this for initialization
		void Start ()
		{
				dialog = new List<string> ();
				dialog.Add ("Viktor vika begai!");
				dialog.Add ("Nema");
				dialog.Add ("Shto?");
				dialog.Add ("Shtot si punta");
				dialog.Add ("Mari ouuuuu");
				dialog.Add ("Problem?");
				dialog.Add ("Mi ne");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (isDialogOpen && Input.GetKeyDown ("space")) {
						dialogCounter++;
				}
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				isDialogOpen = true;
		}

		void OnCollisionExit2D (Collision2D collision)
		{
				isDialogOpen = false;
				dialogCounter = 0;
		}

		void OnGUI ()
		{
				int maxGroupWidth = Screen.width;
				int maxGroupHeight = Screen.height;
				
				int dialogWidth = maxGroupWidth - 20;
				int dialogHeight = maxGroupHeight / 3;

				GUI.BeginGroup (new Rect (10, 10, maxGroupWidth, maxGroupHeight));

				GUIStyle boxStyle = GUI.skin.GetStyle ("box");
				boxStyle.alignment = TextAnchor.UpperLeft;
				boxStyle.normal.textColor = Color.black;
				boxStyle.normal.background = dialogBackground;

				GUIStyle buttonStyle = GUI.skin.GetStyle ("button");
				buttonStyle.alignment = TextAnchor.LowerCenter;

				if (isDialogOpen && dialogCounter < dialog.Count) {
						if (dialogCounter % 2 == 0) {
								GUI.Box (new Rect (0, 0, dialogWidth, dialogHeight), new GUIContent (dialog [dialogCounter], npc), boxStyle);
						} else {
								GUI.Box (new Rect (0, 0, dialogWidth, dialogHeight), new GUIContent (dialog [dialogCounter], player), boxStyle);
						}
						
						GUI.Button (new Rect (dialogWidth / 4 * 2 - dialogWidth / 4 / 2, dialogHeight - dialogHeight / 6, dialogWidth / 4, dialogHeight / 6), "Next", buttonStyle);
						
				}


				GUI.EndGroup ();
		
		}
}
