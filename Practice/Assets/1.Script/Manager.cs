using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager _instance;
    public static Manager Instance { get { return _instance; } }

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if(go == null)
            {
                go = new GameObject {name = "@Manager"};
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Manager>();
        }

        if(player == null)
        {
            GameObject go = FindObjectOfType<PlayerController>().gameObject;
            if(go == null)
            {
                go = Resources.Load<GameObject>("Prefabs/Player");
                player = Instantiate(go);
                return;
            }
            player = go;
        }
    }

    public GameObject player;
}
