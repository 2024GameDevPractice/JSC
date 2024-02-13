using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    public int damage;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)//º®
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 8)//Àû
        {
            collision.GetComponent<EnemyController>().HP -= damage;
            if(collision.GetComponent<EnemyController>().HP <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
