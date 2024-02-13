using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    Animator anim;

    public float shotSpeed;
    public float shotCool;
    float shotcurTime;

    public GameObject bullet;
    public UI_State state;
    public int _damage;
    public int hp;
    bool notDamage = false;
    public int HP { get { return hp; }
        set 
        {
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
            anim.Play("NotDamage");
            notDamage = true;
        }
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        Manager.Instance.player = gameObject;
        state.SetHP();
        shotcurTime = shotCool;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
                GameObject go = Instantiate(bullet);
                go.GetComponent<P_Bullet>().damage = _damage;
                go.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
                go.transform.position = transform.position;
            }
        }
        else
            shotcurTime += Time.deltaTime;
    }

    void EndNoDamage()
    {
        notDamage = false;
    }
}
