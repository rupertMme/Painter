using UnityEngine;
using System.Collections;

public class DwellTimeBar : MonoBehaviour {
    private Color barColor;
	// Use this for initialization
    void Start()
    {
        
}
	
	// Update is called once per frame
	void Update () {
        renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, Screen.width, Input.mousePosition.x));
        renderer.material.SetColor("_SpecColor", barColor);
	
	}

    public Color setBarColor(string colorName)
    {
        switch (colorName)
        {

            case "Black1":
                barColor=Color.black;
                return barColor;
            case "Blue": 
                 barColor=Color.blue;
                return barColor;
            case "Cyan":
                barColor=Color.cyan;
                return barColor;
            case "grey":
              barColor=Color.grey;
                return barColor;
            case "green":
                barColor=Color.green;
                return barColor;
            case "magenta":
                barColor=Color.magenta;
                return barColor;
            case "red":
                barColor=Color.red;
                return barColor;
            case "yellow":
                barColor=Color.yellow;
                return barColor;

        }
        
        return barColor;
    }
    
}
