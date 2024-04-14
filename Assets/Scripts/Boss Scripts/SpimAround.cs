   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class SpimAround : MonoBehaviour
{
    public GameObject ps1;
    public GameObject ps2;
    SpriteRenderer sprite;
    private Vector3 middle;
    public float speed;
    int myLaser;
    float alpha = 0;
    ArrayList laserClockwiseArr = new ArrayList(0);
    ArrayList laserDestroyArr = new ArrayList(0);
    static Regex rx = new Regex("\\d+");
    string[] one;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        MakeLaser.laserTot++;
        myLaser = MakeLaser.laserTot;

        MatchCollection clockwise = rx.Matches(MakeLaser.laserClockwiseStatic);
        foreach (Match match in clockwise)
        {
            int ci = Convert.ToInt32(match.ToString());
            laserClockwiseArr.Add(ci);
        }
        string str = MakeLaser.laserDestroyTimessStatic;
        one = str.Split(' ');
        for (int i = 0; i < MakeLaser.numLaserStatic; i++)
        {
            laserDestroyArr.Add(Convert.ToSingle(one[i]));
        }

        if (Convert.ToInt32(laserClockwiseArr[myLaser]) == 0)
        {
            speed *= -1;
            ps1.SetActive(true);
            ps2.SetActive(false);
        }
        else
        {
            ps1.SetActive(false);
            ps2.SetActive(true);
        }

        StartCoroutine(LaserDestroy(0.0f, 0.1f));
        middle = new Vector3(0, 0, 0);
       
    }

    void Update()
    {
        transform.RotateAround(middle, Vector3.forward, speed * Time.deltaTime);
    }

    IEnumerator LaserDestroy(float aValue, float aTime)
    {
        yield return new WaitForSecondsRealtime(Convert.ToInt32(laserDestroyArr[MakeLaser.laserTot]));

        alpha = sprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            sprite.color = newColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}
