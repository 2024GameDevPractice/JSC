using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    static Manager _instance;
    public static Manager Instance { get { return _instance; } }

    void Awake()
    {
        Init();
        level = 1;
        SetRank();
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
    }

    private void Update()
    {
        if (playing)
        {
            playTime += Time.deltaTime;
        }
    }

    public class Rank
    {
        public int score;
        public string name;
    }

    public List<Rank> ranks = new List<Rank>();
    public void SetRank()
    {
        if (ranks.Count == 0)
        {
            AddRank();
            AddRank();
            AddRank();
        }

        for(int i=2; i >= 0; i--)
        {
            if (ranks[i].score < score)
            {
                int s = ranks[i].score;
                string n = ranks[i].name;
                ranks[i].score = score;
                ranks[i].name = name;

                if(i != 2)
                {
                    ranks[i + 1].score = s;
                    ranks[i+1].name = n;
                }
            }
            else
                break;
        }
    }

    void AddRank()
    {
        Rank rank = new Rank();
        ranks.Add(rank);
        rank.score = 0;
        rank.name = "Player";
    }

    public GameObject player;

    public int stage;

    public int score;
    public int level;

    public float playTime;

    public bool playing;

    public string name;
}
