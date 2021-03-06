﻿// ----------------------------------------------------------------------------
//
// (C) Copyright 2014, Visual Interaction GmbH 
//
// All rights reserved. This work contains unpublished proprietary 
// information of Visual Interaction GmbH and is copy protected by law. 
// (see accompanying file eula.pdf)
//
// ----------------------------------------------------------------------------


using UnityEngine;
using System.Collections;
using iViewX;

public class RotateObjectWhileFocused : MonoBehaviourWithGazeComponent{

    // Setup the RotationSpeed of the Rotation
    //public float rotationsPerMinute = 100.0f;
    private Color textureColor;
    private float dwellTime=0;
    private float dwellTimeMax = 1.5f;
    
    

    
    public override void OnGazeEnter(RaycastHit2D hit)
    {
       
    }

    //Rotate the Element if the Gaze stays on the Collider
    public override void OnGazeStay(RaycastHit2D hit)
    {
        GameObject colorPicker = GameObject.FindGameObjectWithTag("MainCamera");
        if (gameObject.tag == "ColorPicker")
        {

            //colorPicker.GetComponent<malStateManager>().setMalState(true);

            string newColor = gameObject.renderer.name;
            colorPicker.GetComponent<GUIColorPicker>().SetColor(newColor);
            
        }
        else if (gameObject.tag == "Malobject")
        {
            
            if (colorPicker.GetComponent<malStateManager>().getMalState()==true)
            {
                
            
           
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {

                textureColor = colorPicker.GetComponent<GUIColorPicker>().GetColor();


                //transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
                //Debug.Log("Color im Focus");
                gameObject.renderer.material.color = textureColor;
                colorPicker.GetComponent<malStateManager>().setMalState(false);
                 
            }
           
               
            }

            
      
        }

    }


    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
        GameObject colorPicker = GameObject.FindGameObjectWithTag("MainCamera");
        dwellTime = 0;
        GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        if (gameObject.tag == "ColorPicker")
        {
            colorPicker.GetComponent<malStateManager>().setMalState(true);
        }
        
    }
}
