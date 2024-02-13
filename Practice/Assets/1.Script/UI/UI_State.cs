using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_State : MonoBehaviour
{
    PlayerController player;
    public TextMeshProUGUI hpText;

    public Image fuel;
    float fuelcurTime;

    public int repairCnt;
    public int bombCnt;
    public TextMeshProUGUI R_CText;
    public TextMeshProUGUI B_CText;
    public Image repairImage;
    public Image bombImage;
    public GameObject bomb;

    float bombCurTime;
    float repairCurTime;
    void Start()
    {
        R_CText.text = $"{repairCnt}";
        B_CText.text = $"{bombCnt}";
        player = Manager.Instance.player.GetComponent<PlayerController>();
        player.state = GetComponent<UI_State>();
    }

    void Update()
    {
        SetFuel();

        if (repairCnt != 0)
        {
            if (repairCurTime >= 10)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Repair();
                }
            }
            else
            {
                repairCurTime += Time.deltaTime;
                repairImage.fillAmount = repairCurTime / 10;

                if (repairCurTime >= 10)
                    repairImage.color = Color.white;
            }
        }
        if (bombCnt != 0)
        {
            if (bombCurTime >= 10)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Bomb();
                }
            }
            else
            {

                bombCurTime += Time.deltaTime;
                bombImage.fillAmount = bombCurTime / 10;

                if (bombCurTime >= 10)
                    bombImage.color = Color.white;
            }
        }
    }

    public void SetHP()
    {
        hpText.text = $"HP : {player.HP}";
    }

    void SetFuel()
    {
        if (fuelcurTime >= 0.5f)
        {
            fuelcurTime = 0;
            fuel.fillAmount -= 0.005f;
        }
        else
            fuelcurTime += Time.deltaTime;
    }

    void Repair()
    {
        if(player.HP == 4)
            return;

        repairImage.color = Color.red;
        repairCurTime = 0;
        player.HP++;
        repairCnt--;
        R_CText.text = $"{repairCnt}";

       if(repairCnt == 0)
        {
            repairImage.fillAmount = 1;
        }
    }

    void Bomb()
    {
        bombImage.color = Color.red;
        bombCurTime = 0;
        GameObject go = Instantiate(bomb);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * 4;
        go.transform.position = player.transform.position;
        bombCnt--;
        B_CText.text = $"{bombCnt}";

        if (bombCnt == 0)
        {
            bombImage.fillAmount = 1;
        }
    }
}
