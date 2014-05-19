using UnityEngine;
using System.Collections;

public class striptShowGazeData : MonoBehaviour {
    public bool isGazeCursorActive = true;
    public Texture2D gazeCursor;
    public Texture2D gazeCursorBlack;
    public Texture2D gazeCursorBlue;
    public  Texture2D gazeCursorCyan;
    public  Texture2D gazeCursorgrey;
    public  Texture2D gazeCursorgreen;
    public  Texture2D gazeCursormagenta;
    public  Texture2D gazeCursorred;
    public  Texture2D gazeCursoryellow;

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
    public Texture2D setCursor(string color)
    {
        switch (color)
        {
            case "Black1":
                gazeCursor = gazeCursorBlack;
                return gazeCursor;
            case "Blue": 
                 gazeCursor = gazeCursorBlue;
                return gazeCursor;
            case "Cyan":
                gazeCursor = gazeCursorCyan;
                return gazeCursor;
            case "grey":
                gazeCursor = gazeCursorgrey;
                return gazeCursor;
            case "green":
                gazeCursor = gazeCursorgreen;
                return gazeCursor;
            case "magenta":
                gazeCursor = gazeCursormagenta;
                return gazeCursor;
            case "red":
                gazeCursor = gazeCursorred;
                return gazeCursor;
            case "yellow":
                gazeCursor = gazeCursoryellow;
                return gazeCursor;

        }
        
        return gazeCursor;
    }
    public Texture2D getCursor()
    {
        return gazeCursor;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
