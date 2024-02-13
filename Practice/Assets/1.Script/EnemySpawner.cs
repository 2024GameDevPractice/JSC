using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] points;
    public float spawnCool;
    float spawnCurTime;
    void Start()
    {
        
    }
    
    void Update()
    {
        if(spawnCurTime >= spawnCool)
        {
            spawnCurTime = 0;
            GameObject e = Instantiate(enemy);
            int p = Random.Range(0, points.Length);
            Vector3 pos = new Vector3(Random.Range(-3f,4f), Random.Range(-1f, 3f));
            e.transform.position = points[p].transform.position + pos;
        }
        else
            spawnCurTime += Time.deltaTime;
    }
}
