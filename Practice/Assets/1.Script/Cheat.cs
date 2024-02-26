using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    public UI_State state;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(25f, 25f), 0);
            foreach (Collider2D col in cols)
            {
                if (col.gameObject.layer == 8)
                {
                    if (col.GetComponent<Boss1>() != null)
                        return;
                    Destroy(col.gameObject);
                }
                

                if (col.gameObject.layer == 10)
                {
                    Destroy(col.gameObject);
                }

                if (col.gameObject.layer == 11)
                {
                    Destroy(col.gameObject);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            Manager.Instance.player.GetComponent<PlayerController>().level = 4;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            state.bombCnt = state.bombMaxCnt;
            state.repairCnt = state.repairMaxCnt;
            state.repairCurTime = 10;
            state.bombCurTime = 10;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            Manager.Instance.player.GetComponent<PlayerController>().hp = 4;
            state.SetHP();
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            state.fuel.fillAmount = 1;
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
                return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
