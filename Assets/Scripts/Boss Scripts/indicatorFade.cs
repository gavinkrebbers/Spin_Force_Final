using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorFade : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite yellowLaser;
    public float fadeTime;
    float alpha = 0;
    public float R;
    public float G;
    public float B;
    public bool fadesOut;
    public bool isLaser;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        
        if (isLaser)
        {
            if (MakeLaser.laserIsYellowStatic)
            {
                sr.sprite = yellowLaser;
            }
            sr.color = MakeLaser.laserColourStatic;
            R = MakeLaser.laserColourStatic.r * 255; 
            G = MakeLaser.laserColourStatic.g * 255; 
            B = MakeLaser.laserColourStatic.b * 255; 
        }
        else
        {
            sr.color = new Color(R / 255, G / 255, B / 255, 0);
        }
    }
    private void Update()
    {
        StartCoroutine(FadeTo(1.0f, fadeTime));

        IEnumerator FadeTo(float aValue, float aTime)
        {
            alpha = sr.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(R / 255, G / 255, B / 255, Mathf.Lerp(alpha, aValue, t));
                sr.color = newColor;
                yield return null;
            }
        }
    }
   
}
