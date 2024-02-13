using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject eft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)//º®
        {
            Boom();
        }
        if (collision.gameObject.layer == 8)//Àû
        {
            Boom();
        }
        if (collision.gameObject.layer == 10)//Àû
        {
            Boom();
        }
    }

    void Boom()
    {
        Instantiate(eft);

        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position,new Vector2(25f,25f),0);
        foreach(Collider2D col in cols)
        {
            if(col.gameObject.layer == 8)
            {
                col.GetComponent<EnemyController>().HP -= 70;
                if(col.GetComponent<EnemyController>().HP <= 0)
                {
                    Destroy(col.gameObject);
                }
            }

            if (col.gameObject.layer == 10)
            {
                Destroy(col.gameObject);
            }

            if (col.gameObject.layer == 11)
            {
                col.GetComponent<Asternoid>().hp -= 70;
                if (col.GetComponent<Asternoid>().hp <= 0)
                {
                    Destroy(col.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }
}
