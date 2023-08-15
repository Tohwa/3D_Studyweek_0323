using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateObjective : MonoBehaviour
{
    public TextMeshProUGUI _objectiveOne;

    private void Update()
    {
        SetObjectiveText();
    }

    public void SetObjectiveText()
    {
        _objectiveOne.text = GameManager.Instance.objectiveOne;
    }
}
