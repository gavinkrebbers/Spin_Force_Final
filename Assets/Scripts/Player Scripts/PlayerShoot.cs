using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public int bulletSpeed = 200;
    public float shootDelay = 1;
    public int numBullets = 1;
    public float bulletOffset = 0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Boss");
        StartCoroutine("ShootBullet");

    }

    IEnumerator ShootBullet()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        dir.x -= bulletOffset * numBullets / 2;
        dir.y -= bulletOffset * numBullets / 2;
        dir.z = 5;
        for (int i = 0; i < numBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, 1.6f));

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(dir * bulletSpeed);
            dir.x += bulletOffset;
            dir.y += bulletOffset;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("ShootBullet");
    }

}
