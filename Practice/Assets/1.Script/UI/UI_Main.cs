using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Main : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject help;
    [SerializeField] GameObject rank;
    [SerializeField] GameObject Leave;

    [SerializeField] GameObject name;

    private void Start()
    {
        UI_EventHandler evt = start.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { Instantiate(name); };

        evt = help.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(3); };

        evt = rank.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(4); };

        evt = Leave.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { Application.Quit(); };
    }
}
