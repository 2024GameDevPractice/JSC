using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float guardTime;

    private void Update()
    {
        if (guardTime <= 0)
            gameObject.SetActive(false);
        else
            guardTime -= Time.deltaTime;
    }


    public void AddTime()
    {
        guardTime += 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 10)
            Destroy(collision.gameObject);
    }
}
