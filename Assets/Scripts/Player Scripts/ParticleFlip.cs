using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFlip : MonoBehaviour
{
    public GameObject ps1;
    public GameObject ps2;
    public static bool clockwise = false;

    private void Start()
    {
        if (Particles.particles)
        {
            ps1.SetActive(true);
            ps2.SetActive(false);
        }
        else
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
        }
    }

    void Update()
    {
        if (!RotateAround.dead)
        {
            if (Input.GetKeyDown("space"))
            {
                if (clockwise)
                {
                    clockwise = false;
                }
                else
                {
                    clockwise = true;
                }
            }
            if (Particles.particles)
            {
                if (!clockwise)
                {
                    ps1.SetActive(true);
                    ps2.SetActive(false);
                }
                else
                {
                    ps1.SetActive(false);
                    ps2.SetActive(true);
                }
            }
            else
            {
                ps1.SetActive(false);
                ps2.SetActive(false);
            }
        }
        
    }
}
