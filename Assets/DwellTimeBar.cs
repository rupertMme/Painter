using UnityEngine;
using System.Collections;

public class DwellTimeBar : MonoBehaviour {
    private Color barColor;
    private float dwellTime;

	// Use this for initialization
    void Start()
    {
        
}
	
	// Update is called once per frame
	void Update () {
        GameObject Camera= GameObject.FindGameObjectWithTag("MainCamera");
        barColor = Camera.GetComponent<GUIColorPicker>().GetColor();
        renderer.material.SetFloat("_Cutoff", (Mathf.InverseLerp(1,0, dwellTime))+0.0001f);
        //renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, Screen.width, Input.mousePosition.x));
        renderer.material.SetColor("_Color", barColor);
       // renderer.material.color = barColor;
        //renderer.material.SetColor("_MainTex", barColor);
	
	}
    public float setDwelltime(float dwellTimenew)
    {
        dwellTime = dwellTimenew;
        return dwellTime;
    }
 /*
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
    }*/
    
}
