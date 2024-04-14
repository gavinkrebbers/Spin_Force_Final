using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public static bool particles = true;
    Color maxColour;

    void Awake()
    {
        if (particles)
        {
            if (MakeLaser.laserIsYellowStatic)
            {
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.9339623f, 0.6739179f, 0, 1), new Color(1, 0.8235295f, 0, 1));
            }
            else
            {
                float hMax, sMax, vMax;
                Color.RGBToHSV(MakeLaser.laserColourStatic, out hMax, out sMax, out vMax);
                vMax -= 0.5f;
                maxColour = Color.HSVToRGB(hMax, sMax, vMax);

                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(maxColour, MakeLaser.laserColourStatic);
            }
        }
        else
        {
            enabled = false;
        }
    }
}
