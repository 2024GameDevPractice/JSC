using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Name : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject back;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        UI_EventHandler evt = start.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { Manager.Instance.name = text.text; SceneManager.LoadScene(1); };

        evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { Destroy(gameObject); };
    }
}
