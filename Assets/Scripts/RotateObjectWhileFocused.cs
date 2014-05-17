// ----------------------------------------------------------------------------
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
    public float rotationsPerMinute = 100.0f;
    private Color textureColor;
    private int dwellTime=0;

    
    public override void OnGazeEnter(RaycastHit2D hit)
    {
 
    }

    //Rotate the Element if the Gaze stays on the Collider
    public override void OnGazeStay(RaycastHit2D hit)
    {

       
        //Debug.Log("dwelltime" + dwellTime);
           dwellTime+=1;
           if (dwellTime == 100)
           {
               Debug.Log("dwelltime 10000");
               GameObject colorPicker = GameObject.FindGameObjectWithTag("MainCamera");
               textureColor = colorPicker.GetComponent<GUIColorPicker>().GetColor();


               //transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
               //Debug.Log("Color im Focus");
               gameObject.renderer.material.color = textureColor;
           }
        
        
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
        dwellTime = 0;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
