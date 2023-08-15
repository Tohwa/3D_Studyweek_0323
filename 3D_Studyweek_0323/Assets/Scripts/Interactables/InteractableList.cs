using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableList : MonoBehaviour
{
    public List<GameObject> itemlist = new List<GameObject>();
    private Array taggedItems;
    System.Random rnd = new System.Random();
    private int toFindIndex;
    public static string objectiveOne;

    private void Start()
    {
        taggedItems = GameObject.FindGameObjectsWithTag("inter");

        foreach(GameObject obj in taggedItems)
        {
            itemlist.Add(obj);
        }

        SetObjToFind();
    }

    private void SetObjToFind()
    {
        toFindIndex = rnd.Next(0, itemlist.Count);
        objectiveOne = itemlist[toFindIndex].name;
        itemlist.Remove(itemlist[toFindIndex]);
    }
}
