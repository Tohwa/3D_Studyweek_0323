using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    public static GameManager Instance { get; private set; }
    public PlayerController player { get; private set; }

    public GameUIHandler gameUI { get; private set; }

    public GameObject _testOver;

    [Header("Lists & Arrays")]
    public List<GameObject> itemlist = new List<GameObject>();
    private Array taggedItems;
    
    private System.Random rnd = new System.Random();

    [Header("Booleans")]
    public bool winCondition;

    [Header("Floats")]
    private int toFindIndex;

    [Header("Strings")]
    public string objectiveOne;
    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

    }


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameUI = GameObject.FindWithTag("gameUI").GetComponent<GameUIHandler>();

        _testOver.SetActive(false);

        taggedItems = GameObject.FindGameObjectsWithTag("inter");

        foreach (GameObject obj in taggedItems)
        {
            itemlist.Add(obj);
        }

        SetObjToFind();
    }

    public void SetObjToFind()
    {
        toFindIndex = rnd.Next(0, itemlist.Count);
        objectiveOne = itemlist[toFindIndex].name;
        gameUI.SetNewObjective();
        itemlist.Remove(itemlist[toFindIndex]);
    }
}
