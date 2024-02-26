using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_DeadReport : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stage;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI score;

    [SerializeField] TextMeshProUGUI time;

    
    [SerializeField] GameObject Leave;

    void Start()
    {
        time.text = $"playTime : {(int)Manager.Instance.playTime}";
        stage.text = $"Stage {SceneManager.GetActiveScene().buildIndex}";
        hp.text = $"HP : {Manager.Instance.player.GetComponent<PlayerController>().HP}";
        score.text = $"Score : {Manager.Instance.score}";

        UI_EventHandler evt;

        evt = Leave.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(0); };

        Manager.Instance.SetRank();
        GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/dead"));
    }
}
