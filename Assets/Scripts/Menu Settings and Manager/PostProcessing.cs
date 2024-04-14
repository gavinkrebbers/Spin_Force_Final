using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public static bool VFX = true;
    public PostProcessVolume fiveGum;
    public PostProcessVolume normal;

    void Update()
    {

        if (Settings.fiveGum)
        {
            fiveGum.enabled = true;
            normal.enabled = false;
        }
        else
        {
            if (VFX)
            {
                fiveGum.enabled = false;
                normal.enabled = true;
            }
            else
            {
                fiveGum.enabled = false;
                normal.enabled = false;
            }

        }
    }
}
