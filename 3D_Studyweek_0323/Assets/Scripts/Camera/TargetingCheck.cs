using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetingCheck : MonoBehaviour
{
    [SerializeField] private GameObject redObj;
    [SerializeField] private GameObject blueObj;
    [SerializeField] private GameObject yellowObj;

    public void OnInteractHit(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, transform.forward, out hit, 3);
            if (hit.collider)
            {
                if (hit.transform.tag == "inter" && GameManager.Instance.objectiveOne == hit.transform.name)
                {
                    hit.transform.gameObject.SetActive(false);
                }
                else if(hit.transform.tag == "NPC")
                {
                    ClearObjective();
                }

            }
        }
    }

    private void ClearObjective()
    {
        switch (GameManager.Instance.objectiveOne)
        {
            case "red cube":
                redObj.SetActive(true);
                GameManager.Instance.SetObjToFind();
                break;
            case "blue cube":
                blueObj.SetActive(true);
                GameManager.Instance.SetObjToFind();
                break;
            case "yellow cube":
                yellowObj.SetActive(true);
                GameManager.Instance.SetObjToFind();
                break;
        }
    }
}
