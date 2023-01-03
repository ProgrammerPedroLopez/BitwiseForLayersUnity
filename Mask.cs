using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Camera cam;
    public string []layername;
    public int culling_mask;

    string result;

    /*
     * This script has an array of the names of consecutives layers
     * alternates the display with the w key
     */

    void Start()
    {
        //Bit 0 Layer name nothing/everything
        //Bit 1 Layer name default
        //Bit 2 Layer name transparentFX
        //Bit 3 Layer name ignore raycast
        //Bit 4 Layer name water
        //Bit 5 Layer name UI
        //Bit 6 Layer name CUSTOM MASK 0
        //Bit 7 Layer name CUSTOM MASK 1
        //Bit 8 Layer name CUSTOM MASK 2

        result = "Layers " + Convert.ToString(LayerMask.GetMask(layername), toBase: 2);
        Debug.Log(result);
        //output
        //0000 0000 0000 0000 0000 0001 1100 0000

        result = "~ " + Convert.ToString(~LayerMask.GetMask(layername), toBase: 2);
        Debug.Log(result);
        //output
        //1111 1111 1111 1111 1111 1110 0011 1111

        result = "culling mask " + Convert.ToString(cam.cullingMask, toBase: 2);
        Debug.Log(result);
        //output depend on the select dropbox in inspector

        result = "shift " + Convert.ToString((1 << LayerMask.NameToLayer(layername[culling_mask])), toBase: 2);
        Debug.Log(result);
        //output
        //0100 0000
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            culling_mask++;   
        }
        if (culling_mask > (layername.Length - 1))
        {
            culling_mask = 0;
        }

        //show the items in all the others layer
        cam.cullingMask &= ~LayerMask.GetMask(layername);

        //show the items in the select layer with the or and the shift
        cam.cullingMask |= 1 << LayerMask.NameToLayer(layername[culling_mask]);
    }
}
