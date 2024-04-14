using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    SpriteRenderer bossSR;
    public static int bossHealth;
    public int maxBossHealth;
    public Slider bossHealthSlider;
    public ParticleSystem deathPS;
    public Image winPanel;
    float winAlpha;
    float bossAlpha;

    void Start()
    {
        bossSR = GetComponent<SpriteRenderer>();
        bossHealthSlider.maxValue = maxBossHealth;
        bossHealthSlider.value = maxBossHealth;
        bossHealth = maxBossHealth;
        StartCoroutine("Boss");
    }
    IEnumerator Boss()
    {
        yield return new WaitForSeconds(0.9f);
        if(bossHealth == 0)
        {
            MenuButtonScript.curScene = SceneManager.GetActiveScene().buildIndex;
            deathPS.Play();
            while(bossSR.color.a > 0)
            {
                bossAlpha = bossSR.color.a;
                bossSR.color = new Color(bossSR.color.r, bossSR.color.r, bossSR.color.r, bossAlpha -= 0.02f);
                yield return new WaitForSeconds(0.005f);

            }
            yield return new WaitForSeconds(1.5f);
            while (winPanel.color.a < 1)
            {
                winAlpha = winPanel.color.a;
                winPanel.color = new Color(0.1792453f, 0.1792453f, 0.1792453f, winAlpha += 0.01f);
                yield return new WaitForSeconds(0.01f);
            }
            ParticleFlip.clockwise = false;

            SceneManager.LoadScene("WinScene");
        }
        bossHealth--;
        bossHealthSlider.value--;
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        yield return 
        StartCoroutine("Boss");
    }
}
