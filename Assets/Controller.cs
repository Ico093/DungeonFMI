using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Texture2D boxBackground;
	public Texture2D bonus1;
	public Texture2D bonus2;
	public Texture2D bonus3;
	public Texture2D bonus4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		GUIStyle boxStyle=GUI.skin.GetStyle("box");
		boxStyle.fontSize = 15;
		boxStyle.alignment = TextAnchor.MiddleCenter;
		boxStyle.normal.background = boxBackground;
		
		int maxGroupWidth = Screen.width;
		int maxGroupHeight = Screen.height / 8;
		GUI.BeginGroup (new Rect (0, 0, maxGroupWidth, maxGroupHeight));
		
		int singleWidth = maxGroupWidth / 4;
		
		GUI.Box(new Rect(0,0,singleWidth,maxGroupHeight),new GUIContent(""+padMove._value[1].ToString()+" MS",bonus1),boxStyle);
		GUI.Box(new Rect(singleWidth,0,singleWidth,maxGroupHeight),new GUIContent(""+"0."+padMove._value[2].ToString()+" AS",bonus2),boxStyle);
		GUI.Box(new Rect(singleWidth*2,0,singleWidth,maxGroupHeight),new GUIContent(""+padMove._value[3].ToString()+" HP",bonus3),boxStyle);
		GUI.Box(new Rect(singleWidth*3,0,singleWidth,maxGroupHeight),new GUIContent(""+padMove._value[4].ToString()+" DMG",bonus4) ,boxStyle);
		
		
		GUI.EndGroup ();
	}

}
