using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;


public class MakeLaser : MonoBehaviour
{
    public Color laserColour;
    public bool laserIsYellow;
    public static bool laserIsYellowStatic;
    public static Color laserColourStatic;
    public GameObject laserPrefab;
    public int numLasers;
    public string laserTimes;
    public string laserAngles;
    public static string laserDestroyTimessStatic;
    public string laserDestroyTimes;
    public static string laserClockwiseStatic;
    public static int numLaserStatic;
    public string laserClockwise;
    public static int laserTot = -1;
    public GameObject indicatorPrefab;
    string[] one;
    string[] two;
    Animator anim;
    static Regex rx = new Regex("\\d+");
    ArrayList laserTimesArr = new ArrayList(0);
    ArrayList laserAnglesArr = new ArrayList(0);

    void Start()
    {
        laserTot = -1;

        one = laserTimes.Split(' ');
        for (int i = 0; i < one.Length; i++)
        {
            laserTimesArr.Add(Convert.ToDouble(one[i]));
        }
        numLaserStatic = numLasers;

        two = laserAngles.Split(' ');
        for (int i = 0; i < two.Length; i++)
        {
            laserAnglesArr.Add(Convert.ToDouble(two[i]));
        }


        anim = GetComponent<Animator>();
        laserDestroyTimessStatic = laserDestroyTimes;
        laserClockwiseStatic = laserClockwise;
        StartCoroutine("Laser");
        StartCoroutine("Indicator");
        if (laserIsYellow)
        {
            laserIsYellowStatic = true;
            laserColourStatic = new Color(1, 1, 1, 1);
        }
        else
        {
            laserColourStatic = laserColour;
        }
    }

    IEnumerator Pulse()
    {
        anim.Play("Pulse");
        yield return new WaitForSeconds(0.2f);
        anim.Play("Idle");
    }

    IEnumerator Laser()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < laserAnglesArr.Count; i++)
        {
            yield return new WaitForSeconds(Convert.ToSingle(laserTimesArr[i]));
            StartCoroutine("Pulse");
            Instantiate(laserPrefab, gameObject.transform.position + new Vector3(0, 0, 10), Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]))));
        }
    }

    IEnumerator Indicator()
    {

        for (int i = 0; i < laserAnglesArr.Count; i++)
        {
            yield return new WaitForSeconds(Convert.ToSingle(laserTimesArr[i]));
            Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]) - 90)));
        }
    }


}





    //public GameObject MusicManager;
    //public Color laserColour;
    //public bool laserIsYellow;
    //public static bool laserIsYellowStatic;
    //public static Color laserColourStatic;
    //public GameObject laserPrefab;
    //public static int numLaserStatic;
    //public int numLasers;
    //public string laserTimes;
    //public string laserAngles;
    //public static string laserDestroyTimessStatic;
    //public string laserDestroyTimes;
    //public static string laserClockwiseStatic;
    //public string laserClockwise;
    //public static int laserTot = -1;
    //public static bool paused = false;
    //public GameObject indicatorPrefab;
    //Animator anim;
    //ArrayList laserTimesArr = new ArrayList(0);
    //ArrayList laserAnglesArr = new ArrayList(0);
    //string[] one;
    //string[] two;

    //void Start()
    //{
    //    numLasers = numLaserStatic;
    //    if (laserIsYellow)
    //    {
    //        laserIsYellowStatic = true;
    //        laserColourStatic = new Color(1, 1, 1, 1);
    //    }
    //    else
    //    {
    //        laserColourStatic = laserColour;
    //    }
    //    one = laserTimes.Split(' ');
    //    for (int i = 0; i < one.Length; i++)
    //    {
    //        laserTimesArr.Add(Convert.ToDouble(one[i]));
    //    }

    //    two = laserAngles.Split(' ');
    //    for (int i = 0; i < two.Length; i++)
    //    {
    //        laserAnglesArr.Add(Convert.ToDouble(two[i]));
    //    }


    //    anim = GetComponent<Animator>();
    //    laserDestroyTimessStatic = laserDestroyTimes;
    //    laserClockwiseStatic = laserClockwise;
    //    StartCoroutine("Laser");
    //    StartCoroutine("Indicator");
    //}
    /*
    IEnumerator Pulse()
    {
            anim.Play("Pulse");
            yield return (new WaitForSeconds(0.2f), new WaitUntil(() => !paused));

            anim.Play("Idle");
    }

    IEnumerator Laser()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < numLasers; i++)
        {

            
            //Is currently yielding after waiting x seconds OR if it is not paused. It needs to yield for x seconds AND until it is not paused.
            yield return (new WaitForSeconds(Convert.ToInt32(laserTimesArr[i])), new WaitUntil(() => !paused));

                StartCoroutine("Pulse");
                Instantiate(laserPrefab, gameObject.transform.position + new Vector3(0, 0, 10), Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]))));
            
        }
    }

    IEnumerator Indicator()
    {

        for (int i = 0; i < numLasers; i++)
        {
                yield return (new WaitForSeconds(Convert.ToInt32(laserTimesArr[i])), new WaitUntil(() => !paused));

                //MusicManager.GetComponent<AudioManager>().PlayMusic("Level1");

                Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]) - 90)));
            }
    }
    */
    //IEnumerator Pulse()
    //{
    //    anim.Play("Pulse");
    //    yield return new WaitForSeconds(0.2f);

    //    anim.Play("Idle");
    //}

    //IEnumerator Laser()
    //{
    //    yield return new WaitForSeconds(1);

    //    for (int i = 0; i < laserAnglesArr.Count; i++)
    //    {
    //        yield return new WaitForSeconds(Convert.ToSingle(laserTimesArr[i]));
    //        StartCoroutine("Pulse");
    //        Instantiate(laserPrefab, gameObject.transform.position + new Vector3(0, 0, 10), Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]))));
    //    }
    //}

    //IEnumerator Indicator()
    //{

    //    for (int i = 0; i < laserAnglesArr.Count; i++)
    //    {
    //        yield return new WaitForSeconds(Convert.ToSingle(laserTimesArr[i]));
    //        Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, Convert.ToInt32(laserAnglesArr[i]) - 90)));
    //    }
    //}



