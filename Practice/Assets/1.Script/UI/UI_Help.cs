using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Help : MonoBehaviour
{
    [SerializeField] GameObject main;

    private void Start()
    {
        UI_EventHandler evt = main.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData data) => { SceneManager.LoadScene(0); };
    }
}
