using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asternoid : MonoBehaviour
{
    public int hp;
    void Start()
    {
        Invoke("Des", 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)//벽
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 6)//플레이어
        {
            collision.GetComponent<PlayerController>().HP -= 1;
            if (collision.GetComponent<PlayerController>().HP <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 9)//플레이어 공격
        {
            hp -= collision.GetComponent<P_Bullet>().damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }

    void Des()
    {
        Destroy(gameObject);
    }
}
