using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Report : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stage;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI bonus;
    [SerializeField] TextMeshProUGUI time;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Leave;

    void Start()
    {
        UI_EventHandler evt;
        time.text = $"playTime : {(int)Manager.Instance.playTime}";
        stage.text = $"Stage {SceneManager.GetActiveScene().buildIndex}";
        hp.text = $"HP : {Manager.Instance.player.GetComponent<PlayerController>().HP}";
        bonus.text = $"(+{1000} * {Manager.Instance.player.GetComponent<PlayerController>().HP})";
        Manager.Instance.score += 1000 * Manager.Instance.player.GetComponent<PlayerController>().HP;
        score.text = $"Score : {Manager.Instance.score}";

        if (Next != null)
        {
            evt = Next.GetComponent<UI_EventHandler>();
            evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); };
            return;
        }
        evt = Leave.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { Manager.Instance.SetRank(); SceneManager.LoadScene(0); };
    }
}
