using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider cldr)
    {
        if (cldr.CompareTag("Player"))
        {
            GameManager.Instance.loseCondition = true;
        }
    }
}
