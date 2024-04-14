using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floaties : MonoBehaviour
{
    public static bool floaties = true;
    public Color floatyColour;
    public static Color floatyColourStatic;
    public GameObject floaty;
    public static int dirr;
    public float numFloaties;
    public bool Rainbow;
    public static bool RainbowStatic;

    private void Start()
    {
        RainbowStatic = Rainbow;
        if (floaties)
        {
            StartCoroutine(Spawn());
        }
        floatyColourStatic = floatyColour;
    }
    IEnumerator Spawn()
    {
        for(int i = 0; i < 10000; i++)
        {
            yield return new WaitForSeconds(numFloaties);

            int spawnD = Random.Range(1, 5);
            dirr = spawnD;
            SpawnFR(spawnD);
        }
    }

    void SpawnFR(int dir)
    {
        if (dir == 1)
        {
            Instantiate(floaty, new Vector3(Random.Range(-10, 10), 6, 100), new Quaternion(0, 0, Random.Range(-20, 20), 0));
        }
        if (dir == 2)
        {
            Instantiate(floaty, new Vector3(-10, Random.Range(-5, 5), 100), new Quaternion(0, 0, Random.Range(-20, 20), 0));
        }
        if (dir == 3)
        {
            Instantiate(floaty, new Vector3(Random.Range(-10, 10), -6, 100), new Quaternion(0, 0, Random.Range(-20, 20), 0));
        }
        if (dir == 4)
        {
            Instantiate(floaty, new Vector3(10, Random.Range(-5, 5), 100), new Quaternion(0, 0, Random.Range(-20, 20), 0));
        }
    }
}
