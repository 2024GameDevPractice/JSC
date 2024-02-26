using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_State : MonoBehaviour
{
    [SerializeField] GameObject deadReport;

    public PlayerController player;
    public TextMeshProUGUI hpText;

    public Image fuel;
    float fuelcurTime;

    public int repairMaxCnt;
    public int bombMaxCnt;
    [HideInInspector]
    public int repairCnt;
    [HideInInspector]
    public int bombCnt;
    public TextMeshProUGUI R_CText;
    public TextMeshProUGUI B_CText;
    public Image repairImage;
    public Image bombImage;
    public GameObject bomb;

    public float bombCurTime;
    public float repairCurTime;

    public TextMeshProUGUI score;
    void Start()
    {
        SetScore();
        repairCnt = repairMaxCnt;
        bombCnt = bombMaxCnt;
        R_CText.text = $"{repairCnt}";
        B_CText.text = $"{bombCnt}";
        player = Manager.Instance.player.GetComponent<PlayerController>();
        player.state = GetComponent<UI_State>();
    }

    void Update()
    {
        SetFuel();
        SetScore();
        if (repairCnt != 0)
        {
            if (repairCurTime >= 10)
            {
                repairImage.fillAmount = 1;
                repairImage.color = Color.white;
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Repair();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/stop"));
                }
                repairCurTime += Time.deltaTime;
                repairImage.fillAmount = repairCurTime / 10;
            }
        }
        if (bombCnt != 0)
        {
            if (bombCurTime >= 10)
            {
                bombImage.fillAmount = 1;
                    bombImage.color = Color.white;
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Bomb();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/stop"));
                }
                bombCurTime += Time.deltaTime;
                bombImage.fillAmount = bombCurTime / 10;
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
            if(fuel.fillAmount <= 0)
            {
                Instantiate(deadReport);
                Manager.Instance.player.GetComponent<PlayerController>().enabled = false;
            }
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

    void SetScore()
    {
        score.text = $"Score : {Manager.Instance.score}";
    }
}
