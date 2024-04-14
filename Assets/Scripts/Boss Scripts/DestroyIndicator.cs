using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIndicator : MonoBehaviour
{

    public float destroyTime;

    private void Start()
    {
        StartCoroutine("DestroyIn");
    }

    IEnumerator DestroyIn() 
    {

        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
