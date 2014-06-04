using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class menugazeData : MonoBehaviour
{
    public bool isGazeCursorActive = true;
    public Texture2D gazeCursorBlack;
    public GameObject dwellCursor;


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
            GUI.DrawTexture(new Rect(posGaze.x - 5, posGaze.y - 25, gazeCursorBlack.width, gazeCursorBlack.height), gazeCursorBlack);
            //GUI.DrawTexture(new Rect(posGaze.x - 5, posGaze.y - 25, dwellVisual.width/7, dwellVisual.height/7), dwellVisual)
            //dwellCursor.transform.position = camera.ScreenToWorldPoint(new Vector3(posGaze.x+18, -posGaze.y+870 , +0.5F));
            dwellCursor.transform.position = camera.ScreenToWorldPoint(new Vector3(posGaze.x + (dwellCursor.renderer.bounds.size.x / 2) + 10, -posGaze.y + Screen.height + 10, +0.5F));

        }
    }
    // Use this for initialization
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
