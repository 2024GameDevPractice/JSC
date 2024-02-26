using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Rank : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] TextMeshProUGUI n1;
    [SerializeField] TextMeshProUGUI n2;
    [SerializeField] TextMeshProUGUI n3;
    [SerializeField] TextMeshProUGUI s1;
    [SerializeField] TextMeshProUGUI s2;
    [SerializeField] TextMeshProUGUI s3;
    private void Start()
    {
        UI_EventHandler evt = main.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(0); };

        n1.text = Manager.Instance.ranks[0].name;
        n2.text = Manager.Instance.ranks[1].name;
        n3.text = Manager.Instance.ranks[2].name;
        s1.text = $"Score : {Manager.Instance.ranks[0].score}";
        s2.text = $"Score :{Manager.Instance.ranks[1].score}";
        s3.text = $"Score : {Manager.Instance.ranks[2].score}";
    }
}
