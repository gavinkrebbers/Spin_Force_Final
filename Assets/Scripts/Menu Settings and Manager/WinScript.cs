using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public Text damageText;
    public Text deathText;
    void Start()
    {
        PlayerHealth.playerHealth = 0;
        damageText.text = ("DAMAGE TAKEN: " + GameManager.damage);
        deathText.text = ("DEATHS: " + GameManager.deaths);
    }
}
