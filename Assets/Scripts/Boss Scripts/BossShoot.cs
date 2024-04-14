using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject playerRotation;
    public int bulletSpeed = 200;
    public int fasterBulletSpeed = 500;
    public int slowBulletSpeed = 200;
    public float upAng = 90;
    public int downAng = 270;
    public int rightAng = 0;
    public int leftAng = 180;
    public int upRight = 45;
    public int upLeft = 135;
    public int downRight = 315;
    public int downLeft = 225;
    public float rightTriangle = 225;
    public float leftTriangle = 225;
    public float pleft = 20;
    public float pright = 160;

    Vector3 up = new Vector3(0, 1, 0);
    Vector3 down = new Vector3(0, -1, 0);
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);
    Vector3 upLeftV = new Vector3(-0.75f, 0.75f, 0);
    Vector3 upRightV = new Vector3(0.75f, 0.75f, 0);
    Vector3 downLeftV = new Vector3(-0.75f, -0.75f, 0);
    Vector3 downRightV = new Vector3(0.75f, -0.75f, 0);

    float counter;
    public float shootDelay = 1;
    public int numBullets = 1;
    public float bulletOffset = 0f;
    public GameObject player;

    public int rotationSpeed;
    public string curScene;
    bool clockwise = true;
    public Transform top;
    public Transform bottom;
    float temp;

    void Start()
    {
        StopAllCoroutines();
        if (curScene.Equals("TriangleBoss"))
        {
            GameManager.cirleBoss = false;
            StartCoroutine("ShootingTriangle");
        }
        else if (curScene.Equals("SquareBoss"))
        {
            StartCoroutine("ShootingSquare");
            GameManager.cirleBoss = false;
        }
        else if (curScene.Equals("OctagonBoss"))
        {
            GameManager.cirleBoss = false;
            StartCoroutine("ShootingOctagon");
            StartCoroutine("RotatingOctagon");
        }
        else if (curScene.Equals("CircleBoss"))
        {
            GameManager.cirleBoss = true;
            RotateAround.speed = 50;
            StartCoroutine("ShootingCircle");

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            clockwise = !clockwise;
        }

    }

    IEnumerator ShootingTriangle()
    {
        //track player attack
        yield return new WaitForSeconds((0.25f / 20f));
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (i % 40 == 0)
            {
                ShootBullet();

            }
            pointAtPlayer();
        }


        resetRotation();
        for (int i = 0; i < 20; i++)
        {
            rotate(-temp / 20);
            yield return new WaitForSeconds(0.01f);

        }




        //back and forth attack
        for (int i = 0; i < 5; i++)
        {
            shootDeg(90, bulletSpeed);
            shootDeg(215, bulletSpeed);
            shootDeg(325, bulletSpeed);
            yield return new WaitForSeconds(0.2f);

            for (int j = 0; j < 20; j++)
            {
                rotate(3f);
                yield return new WaitForSeconds(0.017f);

            }
            yield return new WaitForSeconds(0.2f);

            shootDeg(30, bulletSpeed);
            shootDeg(150, bulletSpeed);
            shootDeg(270, bulletSpeed);
            yield return new WaitForSeconds(0.2f);

            for (int j = 0; j < 20; j++)
            {
                rotate(3f);
                yield return new WaitForSeconds(0.017f);

            }
            yield return new WaitForSeconds(0.2f);



        }

        resetRotation();
        for (int i = 0; i < 20; i++)
        {
            rotate(-temp / 20);
            yield return new WaitForSeconds(0.01f);

        }

        shootDeg(upAng, bulletSpeed);
        shootDeg(leftTriangle, bulletSpeed);
        shootDeg(rightTriangle, bulletSpeed);
        for (int i = 0; i < 40; i++)
        {


            for (int j = 0; j < 5; j++)
            {
                rotate(1.5f);
                yield return new WaitForSeconds(0.02f);

            }



            shootDeg(upAng + 5, bulletSpeed);
            shootDeg(leftTriangle, bulletSpeed);
            shootDeg(rightTriangle + 10, bulletSpeed);

            upAng += 7.5f;
            leftTriangle += 7.5f;
            rightTriangle += 7.5f;
            yield return new WaitForSeconds(0.01f);


        }




        for (int i = 0; i < 30; i++)
        {
            rotate(12);
            yield return new WaitForSeconds(0.02f);

        }
        for (int i = 0; i < 30; i++)
        {
            rotate(-12);
            yield return new WaitForSeconds(0.02f);

        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 1000; i++)
        {
            rotate(-10);
            yield return new WaitForSeconds(0.01f);

        }
        rotate(100);

    }
    IEnumerator ShootingSquare()
    {
        rotate(55);





        for (int i = 0; i < 12; i++)
        {

            shootDeg(leftAng += 25, bulletSpeed);
            shootDeg(upAng += 25, bulletSpeed);
            shootDeg(rightAng += 25, bulletSpeed);
            shootDeg(downAng += 25, bulletSpeed);
            for (int j = 0; j < 20; j++)
            {
                rotate((25f / 20f));
                yield return new WaitForSeconds((0.25f / 20f));

            }
        }
        leftAng = 235;
        rightAng = 55;
        upAng = 145;
        downAng = 325;
        rotate(11.25f);

        for (int i = 0; i < 12; i++)
        {

            shootDeg(leftAng -= 25, bulletSpeed);
            shootDeg(upAng -= 25, bulletSpeed);
            shootDeg(rightAng -= 25, bulletSpeed);
            shootDeg(downAng -= 25, bulletSpeed);
            for (int j = 0; j < 20; j++)
            {
                rotate(-(25f / 20f));
                yield return new WaitForSeconds((0.25f / 20f));

            }
        }

        for (int i = 0; i < 12; i++)
        {

            shootDeg(leftAng += 10, fasterBulletSpeed);
            shootDeg(upAng += 10, fasterBulletSpeed);
            shootDeg(rightAng += 10, fasterBulletSpeed);
            shootDeg(downAng += 10, fasterBulletSpeed);
            for (int j = 0; j < 20; j++)
            {
                rotate((10f / 20f));
                yield return new WaitForSeconds(0.0001f);

            }
        }



        for (int i = 0; i < 20; i++)
        {
            rotate((175 / 20));
            yield return new WaitForSeconds(0.015f);

        }
        rotate(13.78f);





        for (int i = 0; i < 5; i++)
        {
            shootDiag();
            yield return new WaitForSeconds(0.1f);

            for (int j = 0; j < 20; j++)
            {
                rotate(6.75f);
                yield return new WaitForSeconds(0.025f);

            }
            yield return new WaitForSeconds(0.2f);
            shootHorAndVert();


            yield return new WaitForSeconds(0.1f);

            for (int j = 0; j < 20; j++)
            {
                rotate(6.75f);
                yield return new WaitForSeconds(0.025f);

            }
            yield return new WaitForSeconds(0.2f);




        }



    }
    IEnumerator RotatingOctagon()
    {

        yield return new WaitForSeconds(18.3f);

        for (int i = 0; i < 410; i++)
        {
            rotate(-4);
            yield return new WaitForSeconds(0.017f);

        }

    }
    IEnumerator Hate()
    {

        yield return new WaitForSeconds(2.1f);

        for (int i = 0; i < 1800; i++)
        {

            rotate(-1.13f);
            yield return new WaitForSeconds(0.017f);


        }


    }
    IEnumerator ShootingOctagon()
    {


        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < 15; i++)
        {

            shootHorAndVert();
            yield return new WaitForSeconds(0.2f);

            for (int j = 0; j < 20; j++)
            {
                rotate(2.25f);
                yield return new WaitForSeconds(0.01f);

            }

            shootDiag();
            yield return new WaitForSeconds(0.2f);


            for (int j = 0; j < 20; j++)
            {
                rotate(2.25f);
                yield return new WaitForSeconds(0.01f);

            }


        }
        yield return new WaitForSeconds(13f);
        rotate(-70);

        for (int i = 0; i < 25; i++)
        {
            if (clockwise)
            {
                RotateAround.speed -= 2;

            }
            if (!clockwise)
            {
                RotateAround.speed += 2;

            }

            yield return new WaitForSeconds(0.05f);

        }


        int FUCLK = 35;
        shootDegSlow(upRight);
        shootDegSlow(upLeft);
        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                rotate(FUCLK / 10);
                yield return new WaitForSeconds(0.01f);


            }
            shootDegSlow(upRight += FUCLK);
            shootDegSlow(upLeft += FUCLK);
            yield return new WaitForSeconds(0.05f);

        }


    }
    IEnumerator ShootingCircle()
    {
        yield return new WaitForSeconds(0.075f);

        for (int i = 0; i < 60; i++)
        {

            if (i % 2 == 0)
            {
                shootDegSlow(Random.Range(0, 90));
                shootDegSlow(Random.Range(180, 270));
            }
            else
            {
                shootDegSlow(Random.Range(90, 180));
                shootDegSlow(Random.Range(270, 360));
            }

            yield return new WaitForSeconds(0.13f);
        }
        for (int i = 0; i < 60; i++)
        {
            if (i % 2 == 0)
            {
                shootDegSlow(Random.Range(0, 90));
                shootDegSlow(Random.Range(180, 270));
            }
            else
            {
                shootDegSlow(Random.Range(90, 180));
                shootDegSlow(Random.Range(270, 360));
            }



            yield return new WaitForSeconds(0.11f);
        }
        for (int i = 0; i < 60; i++)
        {
            if (i % 2 == 0)
            {
                shootDegSlow(Random.Range(0, 90));
                shootDegSlow(Random.Range(180, 270));
            }
            else
            {
                shootDegSlow(Random.Range(90, 180));
                shootDegSlow(Random.Range(270, 360));
            }



            yield return new WaitForSeconds(0.095f);
        }
        for (int i = 0; i < 60; i++)
        {

            if (i % 2 == 0)
            {
                shootDegSlow(Random.Range(0, 90));
                shootDegSlow(Random.Range(180, 270));
            }
            else
            {
                shootDegSlow(Random.Range(90, 180));
                shootDegSlow(Random.Range(270, 360));
            }

            yield return new WaitForSeconds(0.085f);
        }





    }
    private void resetRotation()
    {
        temp = playerRotation.transform.rotation.z * 128;
        rotate(temp);
    }
    void setRotation(float str)
    {
        playerRotation.transform.eulerAngles = new Vector3(0, 0, str);

    }
    void ShootBullet()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        Vector3 aAA = new Vector3(transform.position.x, transform.position.y, 10);
        GameObject bullet = Instantiate(bulletPrefab, aAA, Quaternion.Euler(0f, 0f, 2f));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(dir * bulletSpeed);


    }
    void pointAtPlayer()
    {
        Quaternion rotation;
        if (clockwise == true)
        {
            rotation = Quaternion.LookRotation(player.transform.position - top.position, transform.TransformDirection(Vector3.up));

        }
        else
        {
            rotation = Quaternion.LookRotation(player.transform.position - bottom.position, transform.TransformDirection(Vector3.up));

        }

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    void setRotation(int rot)
    {
        playerRotation.transform.eulerAngles = new Vector3(0, 0, rot);

    }
    void rotate(float speed)
    {

        playerRotation.transform.eulerAngles = new Vector3(0, 0, counter += speed);
    }

    void shoot(Vector3 direc, int speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 1.6f));
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        direc = new Vector3(direc.x, direc.y, 100000);
        rb.AddForce(direc * speed);
    }

    void shootDeg(float angle, int speed)
    {
        var vForce = Quaternion.AngleAxis(angle, new Vector3(0, 0, 10000)) * Vector3.right;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 1.6f));
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(vForce * speed);
    }
    void shootDeg(int angle, int speed)
    {
        var vForce = Quaternion.AngleAxis(angle, new Vector3(0, 0, 10000)) * Vector3.right;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 1.6f));
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(vForce * speed);
    }
    void shootDegSlow(float angle)
    {
        var vForce = Quaternion.AngleAxis(angle, new Vector3(0, 0, 10000)) * Vector3.right;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 1.6f));
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(vForce * slowBulletSpeed);
    }
    void resetAllAngs()
    {
        upAng = 90;
        downAng = 270;
        rightAng = 0;
        leftAng = 180;
    }
    void shootAllDir()
    {
        shoot(up, bulletSpeed);
        shoot(down, bulletSpeed);
        shoot(left, bulletSpeed);
        shoot(right, bulletSpeed);
        shoot(upLeftV, bulletSpeed);
        shoot(upRightV, bulletSpeed);
        shoot(downLeftV, bulletSpeed);
        shoot(downRightV, bulletSpeed);

    }


    void shootHorAndVert()
    {
        shoot(up, bulletSpeed);
        shoot(down, bulletSpeed);
        shoot(left, bulletSpeed);
        shoot(right, bulletSpeed);
    }
    void shootDiag()
    {
        shoot(upLeftV, bulletSpeed);
        shoot(upRightV, bulletSpeed);
        shoot(downLeftV, bulletSpeed);
        shoot(downRightV, bulletSpeed);
    }




}



