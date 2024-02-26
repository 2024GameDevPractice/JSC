using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BulletBase : MonoBehaviour
{
    void Start()
    {
        Invoke("Des", 3);
    }

    void Des()
    {
        Destroy(gameObject);
    }
}
