using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] int speed;
    void Start()
    {
        transform.position = new Vector3(1.6f, 18);
    }

    void Update()
    {
        transform.position += new Vector3(0, -Time.deltaTime * speed);
        if(transform.position.y <= -23)
        {
            transform.position = new Vector3(1.6f, 18);
        }
    }
}
