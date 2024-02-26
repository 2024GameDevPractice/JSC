using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public  int score;
    protected Vector3 spawnPos;

    public float moveSpeed;
    protected Vector3 dir;

    protected Animator anim;
    public GameObject bullet;
    public float MaxHp;
    public float hp;
    public float HP { get { return hp; } 
        set 
        { 
            hp = value;
            StartCoroutine(Hited());
            if(hp <= 0)
            {
                anim.enabled = true;
                Death();
            }    
        }
    }

    public float shotSpeed;
    public float shotCool;
    protected float shotcurTime;

    [Header("Item")]
    public GameObject[] items;

    void Start()
    {
        spawnPos = transform.position;
        dir = Vector2.left;
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        Move();
        Shoot();
    }

    protected virtual void Move()
    {
        if (transform.position.x <= spawnPos.x - 0.5f)
            dir = Vector3.right;
        else if (transform.position.x >= spawnPos.x + 0.5f)
            dir = Vector3.left;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        if (shotCool <= shotcurTime)
        {
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/shot"));
            shotcurTime = 0;
            GameObject go = Instantiate(bullet);
            Vector2 dir = (Manager.Instance.player.transform.position - transform.position).normalized;
            go.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
            go.transform.position = transform.position;
        }
        else
            shotcurTime += Time.deltaTime;
    }

    protected virtual void Death()
    {
        if (30 >= Random.Range(0,100))
        { 
            int i = Random.Range(0, items.Length);
            GameObject go = Instantiate(items[i]);
            go.transform.position = transform.position;
        }
        Manager.Instance.score += score;
        GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/explosion"));
        anim.Play("Death");
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Des()
    {
        if(GetComponent<Boss1>() != null)
        {
            GameObject report = Resources.Load<GameObject>("UI/UI_Result");
            Instantiate(report);
        }
        else if(GetComponent<Boss2>() != null)
        {
            GameObject report = Resources.Load<GameObject>("UI/UI_Result2");
            Instantiate(report);
        }
        
        Destroy(gameObject);
    }

    IEnumerator Hited()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
