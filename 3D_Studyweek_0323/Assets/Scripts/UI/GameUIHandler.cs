using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objectivesText;
    private void Start()
    {
        objectivesText.text = $"Objectives:\n{GameManager.Instance.objectiveOne}";
    }

    public void SetObjectiveFound()
    {
        objectivesText.text = $"Objectives:\n<color=green>{GameManager.Instance.objectiveOne}</color>";
    }

    public void SetNewObjective()
    {
        objectivesText.text = $"Objectives:\n<color=white>{GameManager.Instance.objectiveOne}</color>";
    }


}
