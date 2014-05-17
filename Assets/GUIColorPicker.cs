using UnityEngine;
using System.Collections;

public class GUIColorPicker : MonoBehaviour {
    public GUISkin gskin;
    public int toolbarfarbe = 0;
    public Texture[] sprayFarbe;
    private Color brushfarbe;
    public Texture2D black;
    public Texture2D blue;
    public Texture2D cyan;
    public Texture2D grey;
    public Texture2D green;
    public Texture2D magenta;
    public Texture2D red;
    public Texture2D yellow;


	// Use this for initialization
	void Awake () {

        sprayFarbe = new Texture[] { black, blue, cyan , grey, green, magenta, red,yellow};

	}
    void OnGUI()
    {
        GUI.skin = gskin;
        
        GUILayout.BeginArea(new Rect(5,Screen.height-Screen.height/5, Screen.width ,Screen.height/5), "", "Box");
        GUILayout.Label("Spray Farbe ");
        Rect box = new Rect(25,25,Screen.width/5,Screen.height/5);
        
        //Eventuell Buttons in das Rect setzen.


        //toolbarfarbe = GUILayout.SelectionGrid(toolbarfarbe, sprayFarbe, 8);
        //toolbarfarbe = GUI.Toolbar(new Rect(25, 25, Screen.width,Screen.height/5), toolbarfarbe, sprayFarbe);
        
        brushfarbe = brushColor(toolbarfarbe);
        Vector2 mouse = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        //if (Event.current.type==EventType.Repaint && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition)){
        if (box.Contains(mouse))
        {
            Debug.Log("hover über box");
        }

        GUILayout.EndArea();
       
    }
	// Update is called once per frame
	void Update () {
	
	}

    public  Color brushColor(int toolbarfarbe)
    {
        
        switch (toolbarfarbe)
        {
            case 0:
                return Color.black;
            case 1:
                return Color.blue;
            case 2:
                return Color.cyan;
            case 3:
                return Color.gray;
            case 4:
                return Color.green;
            case 5:
                return Color.magenta;
            case 6:
                return Color.red;
            case 7:
                return Color.yellow;

        }

        return brushfarbe;
    }

    public Color GetColor()
    {
        Debug.Log("colorPicker" + brushfarbe);
        return brushfarbe;
    }


}
