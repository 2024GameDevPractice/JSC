using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject deadReport;

    Rigidbody2D rigid;
    public float speed;
    Animator anim;

    public float shotSpeed;
    public float shotCool;
    float shotcurTime;

    public GameObject[] bullets;
    public UI_State state;
    public int level = 1;
   
    public int hp;
    bool notDamage = false;

    public int HP { get { return hp; }
        set 
        {
            if (hp <= 0)
                return;

            if (notDamage && value < hp)
                return;
            if(value > hp)
            {
                hp = value;
                state.SetHP();
                return;
            }
            hp = value; 
            state.SetHP();
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/hit"));
            anim.Play("NotDamage");
            notDamage = true;

            if(hp <= 0)
            {
                anim.Play("Death");
                Instantiate(deadReport);
            }
        }
    }


    void Start()
    {
        Manager.Instance.player = gameObject;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Manager.Instance.score = 0;
            Manager.Instance.playTime = 0;
        }
        Manager.Instance.playing = true;
        state.player = GetComponent<PlayerController>();
        level = Manager.Instance.level;
        anim = GetComponent<Animator>();
        state.SetHP();
        shotcurTime = shotCool;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (HP <= 0)
        {
            rigid.velocity = Vector3.zero;
            return;
        }
        Moving();
        Shoot();
    }

    void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector3(h, v) * speed;
    }

    void Shoot()
    {
        if (shotCool <= shotcurTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shotcurTime = 0;
                switch (level)
                {
                    case 1:
                        Level1();
                        break;
                    case 2:
                        Level2(); 
                        break;
                    case 3:
                        Level3();
                        break;
                    case 4:
                        Level4(); break;

                }
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/shot"));
            }
        }
        else
            shotcurTime += Time.deltaTime;
    }

    void Level1()
    {
        GameObject go = Instantiate(bullets[0]);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
        go.transform.position = transform.position;
    }

    void Level2()
    {
        GameObject go = Instantiate(bullets[1]);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
        go.transform.position = transform.position;
    }

    void Level3()
    {
        GameObject go = Instantiate(bullets[2]);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
        go.transform.position = transform.position;
    }

    void Level4()
    {
        GameObject go = Instantiate(bullets[3]);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
        go.transform.position = transform.position;
    }
    void EndNoDamage()
    {
        notDamage = false;
    }
}
