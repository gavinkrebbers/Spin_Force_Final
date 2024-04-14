using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalDeaths = 0;
    public static int totalDamage = 0;
    public static int deaths = 0;
    public static int damage = 0;
    public static bool cirleBoss;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
