using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public string thingThatKillsBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == thingThatKillsBullet)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == thingThatKillsBullet)
        {
            Destroy(gameObject);
        }
    }
}



