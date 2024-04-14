using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject playerRotation;
    float counter;
    float rotateSpeed;
    int spriteNum;
    public Sprite circle;
    public Sprite triangle;
    public Sprite octagon;
    public Sprite pentagon;
    public Sprite hexagon;
    SpriteRenderer sr;
    float H, S, V;
    Color currentColour;

    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        sr.color = Floaties.floatyColourStatic;

        if (Floaties.RainbowStatic)
        {
            currentColour = GetComponent<SpriteRenderer>().color;
            currentColour = new Color(Rainbow.currentColourStatic.r, Rainbow.currentColourStatic.g, Rainbow.currentColourStatic.b, Floaties.floatyColourStatic.a);
            StartCoroutine("AddH");
        }

        spriteNum = Random.Range(1, 7);
        rotateSpeed = Random.Range(-1, 1);

        if(spriteNum == 1)
        {
            sr.sprite = circle;
        }
        else if(spriteNum == 2)
        {
            sr.sprite = triangle;
        }
        else if(spriteNum == 3)
        {
            sr.sprite = octagon;
        }
        else if(spriteNum == 4)
        {
            sr.sprite = pentagon;
        }
        else if(spriteNum == 5)
        {
            sr.sprite = hexagon;
        }

        if (rotateSpeed > 0)
        {
            rotateSpeed = Random.Range(1, 2);
        }
        else
        {
            rotateSpeed = Random.Range(-1, -2);
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(Floaties.dirr == 1)
        {
            rb.AddRelativeForce(new Vector3(Random.Range(50, -50), Random.Range(50, 100), 0));
        }
        else if(Floaties.dirr == 2)
        {
            rb.AddRelativeForce(new Vector3(Random.Range(-50, -100), Random.Range(50, -50), 0));
        }
        else if(Floaties.dirr == 3)
        {
            rb.AddRelativeForce(new Vector3(Random.Range(50, -50), Random.Range(-50, -100), 0));
        }
        else if(Floaties.dirr == 4)
        {
            rb.AddRelativeForce(new Vector3(Random.Range(50, 100), Random.Range(50, -50), 0));
        }
        StartCoroutine("spin");

    }
    IEnumerator spin()
    {
        for(int i = 0; i < 1000; i++)
        {
            rotate(rotateSpeed);
            yield return new WaitForSeconds(0.01f);
        }
       

    }
    void rotate(float speed)
    {
        playerRotation.transform.eulerAngles = new Vector3(0, 0, counter += speed);
    }

    IEnumerator AddH()
    {
        Color.RGBToHSV(currentColour, out H, out S, out V);
        yield return new WaitForSeconds(0.01f);
        if (H > 1)
        {
            H = 0;
        }
        else
        {
            H += 0.001f;
        }
        currentColour = Color.HSVToRGB(H, S, V);
        currentColour.a = Floaties.floatyColourStatic.a;
        StartCoroutine("SetColour");

    }

    IEnumerator SetColour()
    {
        sr.color = currentColour;
        yield return new WaitForSeconds(0.01f);

        StartCoroutine("AddH");
    }
}
