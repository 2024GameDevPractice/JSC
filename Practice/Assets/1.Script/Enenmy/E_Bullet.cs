using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bullet : MonoBehaviour
{
    public int damage;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)//��
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 6)//�÷��̾�
        {
            collision.GetComponent<PlayerController>().HP -= 1;
            Destroy(gameObject);
        }
    }
}
