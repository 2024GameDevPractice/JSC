using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsternoidSpawner : MonoBehaviour
{
    public GameObject aster;
    public Transform[] points;
    public float spawnCool;
    float spawnCurTime;

    GameObject _target;
    public float astSpeed;
    void Start()
    {
        _target = Manager.Instance.player;
    }

    void Update()
    {
        if (spawnCurTime >= spawnCool)
        {
            spawnCurTime = 0;
            GameObject e = Instantiate(aster);
            int p = Random.Range(0, points.Length);
            Vector3 pos = new Vector3(Random.Range(-3f, 4f), 0);
            e.transform.position = points[p].transform.position + pos;

            Vector2 dir = (_target.transform.position - e.transform.position).normalized;
            e.GetComponent<Rigidbody2D>().velocity = dir * astSpeed;
        }
        else
            spawnCurTime += Time.deltaTime;
    }
}
