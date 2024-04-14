using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateAround : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public ParticleFlip particleFlip;
    public static bool dead;
    public GameObject target;
    public static float speed = 100;

    private void Start()
    {
        speed = 100f;
    }
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
        if (!PlayerHealth.dead && !dead)
        {
            if (Input.GetKeyDown("space"))
            {
                speed *= -1;
            }
        }
        else
        {
            dead = true;
            PlayerHealth.dead = false;
            StartCoroutine("Death");
        }
    }
    IEnumerator Death()
    {
        while(speed != 0)
        {
            if(speed > 0)
            {
                speed -= 1f;
            }
            else
            {
                speed += 1f;
            }
            yield return new WaitForSeconds(0.1f);
        }
        PlayerHealth.playerHealth = 3;
        dead = false;
        pauseMenu.Restart();
        speed = 100f;
    }
}