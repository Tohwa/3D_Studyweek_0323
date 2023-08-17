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
    public BoatTriggerActions boatScript { get; private set; }

    [Header("Lists & Arrays")]
    public List<GameObject> itemlist = new List<GameObject>();
    private Array taggedItems;

    private System.Random rnd = new System.Random();

    [Header("Booleans")]
    public bool winCondition;
    public bool loseCondition;

    [Header("Floats")]
    private int toFindIndex;
    public float timerTime { get; private set; } = 120f;
    public float timerTimeRounded;

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
        boatScript = GameObject.FindWithTag("boat").GetComponent<BoatTriggerActions>();

        taggedItems = GameObject.FindGameObjectsWithTag("inter");

        foreach (GameObject obj in taggedItems)
        {
            itemlist.Add(obj);
        }

        SetObjToFind();
    }

    private void Update()
    {
        if (boatScript._boatRB.velocity.magnitude == 0)
        {
            timerTime -= Time.deltaTime;
            timerTimeRounded = MathF.Round(timerTime);
            gameUI.UpdateTimer();

        }
        if (timerTime < 0)
        {
            loseCondition = true;
        }

        if (loseCondition)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
    }

    public void SetObjToFind()
    {
        toFindIndex = rnd.Next(0, itemlist.Count);
        objectiveOne = itemlist[toFindIndex].name;
        gameUI.ResetObjective();
        itemlist.Remove(itemlist[toFindIndex]);
    }
}
