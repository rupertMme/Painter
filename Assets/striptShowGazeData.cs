using UnityEngine;
using System.Collections;

public class striptShowGazeData : MonoBehaviour {
    public Texture2D gazeCursor;
    public bool isGazeCursorActive = true;

    void OnGUI()
    {
        if (!isGazeCursorActive)
        {
            isGazeCursorActive = true;
        }
        else
        {
            isGazeCursorActive = false;
        }
        if (isGazeCursorActive)
        {
            Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            GUI.DrawTexture(new Rect(posGaze.x, posGaze.y, gazeCursor.width, gazeCursor.height), gazeCursor);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
