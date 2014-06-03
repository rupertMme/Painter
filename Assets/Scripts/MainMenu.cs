using UnityEngine;
using System.Collections;
using iViewX;
using System.Runtime.InteropServices;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {

    public Texture eyePaintlogo;
   
  

	// Use this for initialization

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.45f, Screen.height * .12f, Screen.width * 0.15f, Screen.height * 0.1f), "Start Calibration"))
            GazeControlComponent.Instance.StartCalibration();

        GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.25f, Screen.height*0.25f), eyePaintlogo);

        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .26f, Screen.width * 0.15f, Screen.height * .1f), "football"))
        {
            GameStateManager.Instance.startState("football");
        }

        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .40f, Screen.width * 0.15f, Screen.height * .1f), "Zwerg"))
        {
            GameStateManager.Instance.startState("zwerg");
        }

        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .54f, Screen.width * 0.15f, Screen.height * .1f), "Yoshy"))
        {
            GameStateManager.Instance.startState("yoshy");
        }
        
        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .68f, Screen.width * 0.15f, Screen.height * .1f), "Auto"))
        {
            GameStateManager.Instance.startState("painterTest");
        }
        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .82f, Screen.width * 0.15f, Screen.height * .1f), "Spiel beenden"))
        {
            Application.Quit();
        }

      
    }
	void Start () {
      
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
