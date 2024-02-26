using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.down * 2.5f;
    }

    protected virtual void SetBuff()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            SetBuff();
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/collect"));
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
