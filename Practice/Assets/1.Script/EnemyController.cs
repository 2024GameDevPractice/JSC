using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 spawnPos;

    public float moveSpeed;
    Vector3 dir;

    public GameObject bullet;
    public int damage;
    public float hp;
    public float HP { get { return hp; } 
        set 
        { 
            hp = value; 
            if(hp <= 0)
            {
                Desath();
            }    
        }
    }

    public float shotSpeed;
    public float shotCool;
    float shotcurTime;

    [Header("Item")]
    public GameObject[] items;

    void Start()
    {
        spawnPos = transform.position;
        dir = Vector2.left;
    }

    void Update()
    { 
        Move();
        Shoot();
    }

    private void Move()
    {
        if (transform.position.x <= spawnPos.x - 0.5f)
            dir = Vector3.right;
        else if (transform.position.x >= spawnPos.x + 0.5f)
            dir = Vector3.left;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        if (shotCool <= shotcurTime)
        {
            shotcurTime = 0;
            GameObject go = Instantiate(bullet);
            go.GetComponent<E_Bullet>().damage = damage;
            go.GetComponent<Rigidbody2D>().velocity = Vector2.down * shotSpeed;
            go.transform.position = transform.position;
        }
        else
            shotcurTime += Time.deltaTime;
    }

    void Desath()
    {
        if (20 >= Random.Range(0,100))
        { 
            int i = Random.Range(0, items.Length);
            Instantiate(items[i]);
            Destroy(gameObject);
        }
    }
}
