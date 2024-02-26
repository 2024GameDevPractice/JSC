using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyController
{

    private void Start2()
    {
        anim.enabled = false;
    }
    protected override void Move()
    {
        base.Move();
    }

    protected override void Shoot()
    {
        if (shotCool <= shotcurTime)
        {
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/shot"));
            shotcurTime = 0;
            GameObject go = Instantiate(bullet,transform.position, Quaternion.identity);
            GameObject go2 = Instantiate(bullet,transform.position, Quaternion.identity);
            GameObject go3 = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = Vector2.down * shotSpeed;
            go2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * shotSpeed; 
            go3.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * shotSpeed; 
        }
        else
            shotcurTime += Time.deltaTime;
    }
}
