using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objectivesText;
    [SerializeField] private TextMeshProUGUI itemListText;
    [SerializeField] private GameObject itemList;
    private void Start()
    {
        objectivesText.text = $"Current Objectives:\n{GameManager.Instance.objectiveOne}";
    }

    public void SetObjectiveFound()
    {
        objectivesText.text = $"Current Objectives:\n<color=green>{GameManager.Instance.objectiveOne}</color>";
    }

    public void SetNewObjective()
    {
        objectivesText.text = $"Current Objectives:\n<color=white>{GameManager.Instance.objectiveOne}</color>";
    }

    public void ShowItemList()
    {
        if (itemList.gameObject.activeSelf)
        {
            itemList.SetActive(false);
            return;
        }

        itemList.SetActive(true);
        itemListText.text = "Other Objectives:";

        for (int i = 0; i < GameManager.Instance.itemlist.Count; i++)
        {
            itemListText.text = $"{itemListText.text}\n{GameManager.Instance.itemlist[i].name}";
        }
    }

    public void UpdateItemList()
    {
        itemListText.text = string.Empty;
        itemListText.text = "Other Objectives:";
        for (int i = 0; i < GameManager.Instance.itemlist.Count; i++)
        {
            itemListText.text = $"{itemListText.text}\n{GameManager.Instance.itemlist[i].name}";
        }
    }
}
