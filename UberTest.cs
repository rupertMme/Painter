using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class UberTest : MonoBehaviour
{
    public Texture2D sourceBaseTex;
    private Texture baseTex;

    void Start()
    {
        baseTex = (Texture2D)Instantiate(sourceBaseTex);
    }
};
