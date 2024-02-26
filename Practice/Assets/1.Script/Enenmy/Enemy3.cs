using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    protected override void Move()
    {
        transform.position = new Vector3(Manager.Instance.player.transform.position.x,transform.position.y);
    }

    protected override void Shoot()
    {
        if (shotCool <= shotcurTime)
        {
            shotcurTime = 0;
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/shot"));
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go2 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go3 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go4 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject go5 = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = Vector2.down * shotSpeed;
            go2.GetComponent<Rigidbody2D>().velocity = (Vector2.down + new Vector2(0.2f, 0)) * shotSpeed;
            go3.GetComponent<Rigidbody2D>().velocity = (Vector2.down + new Vector2(-0.2f, 0)) * shotSpeed;
            go4.GetComponent<Rigidbody2D>().velocity = (Vector2.down + new Vector2(-0.4f, 0)) * shotSpeed;
            go5.GetComponent<Rigidbody2D>().velocity = (Vector2.down + new Vector2(0.4f, 0)) * shotSpeed;
        }
        else
            shotcurTime += Time.deltaTime;
    }
        
        
}
