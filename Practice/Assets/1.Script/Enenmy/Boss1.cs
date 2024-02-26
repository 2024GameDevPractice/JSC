using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyController
{

    int skills;
    float changeCurTime;
    bool start;
    protected override void Move()
    {
        if (!start)
            return;
        if (transform.position.x <= spawnPos.x - 5f)
            dir = Vector3.right;
        else if (transform.position.x >= spawnPos.x + 5f)
            dir = Vector3.left;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        if (!start)
            return;

        if (shotCool <= shotcurTime)
        {
            shotcurTime = 0f;
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/shot"));
            switch (skills)
            {
                case 1:
                    Shoot1();
                    break;
                case 2:
                    Shoot2();
                    break;
                case 3:
                    Shoot3();
                    break;
            }
        }
        else
            shotcurTime += Time.deltaTime;

        if (changeCurTime >= 3.5f)
        {
            changeCurTime = 0;
            skills = Random.Range(1, 4);
        }
        else
            changeCurTime += Time.deltaTime;
    }

    void Shoot1()
    {
            moveSpeed = 0.5f;
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go2 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go3 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go4 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go5 = Instantiate(bullet, transform.position, Quaternion.identity);
            shotSpeed = 5;
            shotCool = 1.2f;
            Vector2 dir = (Manager.Instance.player.transform.position - transform.position).normalized;
            go.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
            go2.GetComponent<Rigidbody2D>().velocity = (dir + new Vector2(0.2f, 0)) * shotSpeed;
            go3.GetComponent<Rigidbody2D>().velocity = (dir + new Vector2(-0.2f,0)) * shotSpeed;
            go4.GetComponent<Rigidbody2D>().velocity = (dir + new Vector2(-0.4f,0)) * shotSpeed;
            go5.GetComponent<Rigidbody2D>().velocity = (dir + new Vector2(0.4f,0)) * shotSpeed;
        
    }

    void Shoot2()
    {
        moveSpeed = 0.5f;
        shotSpeed = 3;
        shotCool = 1.5f;
        for(int i = 0; i < 15; i++)
        {
            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / 15), Mathf.Sin(Mathf.PI * 2 * i / 15));
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
        }
    }

    void Shoot3()
    {
        moveSpeed = 6f;
        shotSpeed = 9;
        shotCool = 0.2f;
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.down * shotSpeed;
    }

    void StartBoss()
    {
        start = true;
        anim.enabled = false;
    }

    protected override void Death()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        anim.enabled = true;
        Manager.Instance.level = Manager.Instance.player.GetComponent<PlayerController>().level;
        Manager.Instance.score += score;
        anim.Play("Death");
        Manager.Instance.playing = false;
    }
}
