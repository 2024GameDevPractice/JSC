using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bullet : MonoBehaviour
{
    public int damage;
    

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
    }
}
