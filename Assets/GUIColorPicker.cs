using UnityEngine;
using System.Collections;

public class GUIColorPicker : MonoBehaviour {
    public GUISkin gskin;
    public int toolbarfarbe = 0;
    public Texture[] sprayFarbe;
    private Color brushfarbe=Color.black;
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
        //Rect box = new Rect(25,25,Screen.width/5,Screen.height/5);
        
        //Eventuell Buttons in das Rect setzen.


        //toolbarfarbe = GUILayout.SelectionGrid(toolbarfarbe, sprayFarbe, 8);
        //toolbarfarbe = GUI.Toolbar(new Rect(25, 25, Screen.width,Screen.height/5), toolbarfarbe, sprayFarbe);
        
        //brushfarbe = brushColor(toolbarfarbe);
        //Vector2 mouse = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        //if (Event.current.type==EventType.Repaint && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition)){
        //if (box.Contains(mouse))
       // {
      //      Debug.Log("hover über box");
       // }

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
        return brushfarbe;
    }
    public Color SetColor(string newbrushfarbe)
    {
        switch (newbrushfarbe)
        {
            case "Black1":
                brushfarbe = Color.black;
                gameObject.GetComponent<striptShowGazeData>().setCursor("Black1");
                gameObject.GetComponent<DwellTimeBar>.setBarColor("Black1");
                return brushfarbe;
            case "Blue":
                 brushfarbe = Color.blue;
                 gameObject.GetComponent<striptShowGazeData>().setCursor("Blue");
                return brushfarbe;
           case "Cyan":
                brushfarbe = Color.cyan;
                gameObject.GetComponent<striptShowGazeData>().setCursor("Cyan");
                return brushfarbe;
           case "grey":
                brushfarbe = Color.gray;
                gameObject.GetComponent<striptShowGazeData>().setCursor("grey");
                return brushfarbe;
           case "green":
                brushfarbe = Color.green;
                gameObject.GetComponent<striptShowGazeData>().setCursor("green");
                return brushfarbe;
           case "magenta":
                brushfarbe = Color.magenta;
                gameObject.GetComponent<striptShowGazeData>().setCursor("magenta");
                return brushfarbe;
           case "red":
                brushfarbe = Color.red;
                gameObject.GetComponent<striptShowGazeData>().setCursor("red");
                return brushfarbe;
           case "yellow":
                brushfarbe = Color.yellow;
                gameObject.GetComponent<striptShowGazeData>().setCursor("yellow");
                return brushfarbe;

        }

        return brushfarbe;
    }

}
