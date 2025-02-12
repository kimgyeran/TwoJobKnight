using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(GameManager).Name);
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public AlbaSystem AlbaSystem;
    public DungeonSystem DungeonSystem;
    public long Money;


    void Awake()
    {
        init();
    }
    void init()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }
}
