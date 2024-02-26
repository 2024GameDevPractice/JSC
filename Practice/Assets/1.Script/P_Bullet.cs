using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)//º®
        {
            Destroy(transform.gameObject);
        }
        if (collision.gameObject.layer == 8)//Àû
        {
            collision.GetComponent<EnemyController>().HP -= damage;
            Destroy(gameObject);
        }
    }
}
