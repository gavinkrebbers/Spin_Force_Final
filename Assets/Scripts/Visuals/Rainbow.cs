using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rainbow : MonoBehaviour
{
    float H, S, V;
    SpriteRenderer sr;
    Color currentColour;
    public static Color currentColourStatic;

    void Start()
    {
        currentColour = GetComponent<SpriteRenderer>().color;
        StartCoroutine("AddH");
        sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator AddH()
    {
        Color.RGBToHSV(currentColour, out H, out S, out V);
        yield return new WaitForSeconds(0.01f);
        if(H > 1)
        {
            H = 0;
        }
        else
        {
            H += 0.001f;
        }
        currentColour = Color.HSVToRGB(H, S, V);

        StartCoroutine("SetColour");

    }

    IEnumerator SetColour()
    {
        currentColourStatic = currentColour;
        sr.color = currentColour;
        yield return new WaitForSeconds(0.01f);

        StartCoroutine("AddH");
    }
}
