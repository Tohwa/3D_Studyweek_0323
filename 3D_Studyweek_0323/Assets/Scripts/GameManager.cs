using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerController player { get; private set; }
    public List<GameObject> itemlist = new List<GameObject>();
    private Array taggedItems;
    System.Random rnd = new System.Random();
    private int toFindIndex;
    public string objectiveOne;

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
        itemlist.Remove(itemlist[toFindIndex]);
    }

}
