using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    void Update()
    {
        if (PlayerHealth.playerHealth == 2f)
        {
            heart3.GetComponent<Image>().color = new Color32(255, 255, 255, 20);
        }
        else if (PlayerHealth.playerHealth == 1f)
        {
            heart2.GetComponent<Image>().color = new Color32(255, 255, 255, 20);

        }
        else if (PlayerHealth.playerHealth == 0f)
        {
            heart1.GetComponent<Image>().color = new Color32(255, 255, 255, 20);
        }
    }
}
