using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth = 3;
    public static bool iFrames = false;
    public ScreenShake screenShake;
    public static bool dead;
    public static Scene currentScene;
    void Start()
    {
        PlayerHealth.playerHealth = 3;
        iFrames = false;
        currentScene = SceneManager.GetActiveScene();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet" && !iFrames)
        {
            StartCoroutine("TurnOniFrames");
            playerHealth--;
            GameManager.damage++;
            StartCoroutine(screenShake.Shake(.15f, .3f));
            FindObjectOfType<AudioManager>().Play("Damage");
            if (playerHealth < 1)
            {
                GameManager.deaths++;
                dead = true;
                ParticleFlip.clockwise = false;
                playerHealth = 3;
            }
        }

    }
    IEnumerator TurnOniFrames()
    {
        iFrames = true;
        yield return new WaitForSeconds(0.5f);
        iFrames = false;
    }
}



