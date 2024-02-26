using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] points;
    public float spawnCool;
    float spawnCurTime;

    public GameObject boss;
    public Transform bossPos;
    public float spawnBossTime;
    float spawnBossCurTime;
    bool spawnBoss;

    public Image BossHp; 
    void Start()
    {

    }
    
    void Update()
    {
        if (spawnBoss)
        {
            SetBossHP();
            return;
        }
        if(spawnCurTime >= spawnCool)
        {
            spawnCurTime = 0;
            int es = Random.Range(0, enemy.Length);
            GameObject e = Instantiate(enemy[es]);
            int p = Random.Range(0, points.Length);
            Vector3 pos = new Vector3(Random.Range(-3f,4f), Random.Range(-1f, 3f));
            e.transform.position = points[p].transform.position + pos;
        }
        else
            spawnCurTime += Time.deltaTime;

        SpawnBoss();
    }

    void SpawnBoss()
    {
        if(spawnBossTime <= spawnBossCurTime)
        {
            boss = Instantiate(boss,bossPos.position,Quaternion.Euler(0,0,180));
            if (boss.GetComponent<Boss2>() != null)
                boss.transform.rotation = Quaternion.identity;
            BossHp.color = Color.red;
            spawnBoss = true;
        }
        else
        {
            spawnBossCurTime += Time.deltaTime;
            BossHp.fillAmount = spawnBossCurTime / spawnBossTime;
        }

    }

    void SetBossHP()
    {
        if (boss == null)
            return;
        BossHp.fillAmount = boss.GetComponent<EnemyController>().HP / boss.GetComponent<EnemyController>().MaxHp;
    }
}
