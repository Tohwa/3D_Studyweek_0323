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

    [Header("Components")]
    [SerializeField] private Rigidbody _boatRB;

    [Header("Lists & Arrays")]
    public List<GameObject> itemlist = new List<GameObject>();
    private Array taggedItems;
    
    private System.Random rnd = new System.Random();

    [Header("Floats")]
    private int toFindIndex;
    [SerializeField] private float speed;
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
        taggedItems = GameObject.FindGameObjectsWithTag("inter");

        foreach (GameObject obj in taggedItems)
        {
            itemlist.Add(obj);
        }

        SetObjToFind();

        _boatRB.velocity = transform.forward * Time.deltaTime * speed;
    }

    public void SetObjToFind()
    {
        toFindIndex = rnd.Next(0, itemlist.Count);
        objectiveOne = itemlist[toFindIndex].name;
        itemlist.Remove(itemlist[toFindIndex]);
    }
}
