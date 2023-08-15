using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateObjective : MonoBehaviour
{
    private string objToFindName;
    public TMP_Text _objectiveOne;

    private void Update()
    {
        SetObjectiveText();
    }

    public void SetObjectiveText()
    {
        objToFindName = InteractableList.objectiveOne;
        _objectiveOne.text = objToFindName;
    }
}
