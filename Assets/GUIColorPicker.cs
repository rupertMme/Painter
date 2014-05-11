using UnityEngine;
using System.Collections;

public class GUIColorPicker : MonoBehaviour {
    public GUISkin gskin;
    public int toolbarfarbe = 0;
    public Texture[] sprayFarbe;
    private Color brushfarbe;


	// Use this for initialization
	void Start () {
	
	}
    void OnGUI()
    {
        GUI.skin = gskin;
        
        GUILayout.BeginArea(new Rect(5, 5, 100 ,Screen.height), "", "Box");
        GUILayout.Label("Spray Farbe ");

        toolbarfarbe = GUILayout.SelectionGrid(toolbarfarbe, sprayFarbe, 3);
        
        brushfarbe = brushColor(toolbarfarbe);
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
