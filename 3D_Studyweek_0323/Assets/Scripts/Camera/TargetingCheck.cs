using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetingCheck : MonoBehaviour
{
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
                    Debug.Log("You can interact with this item!");
                }

            }
        }
    }
}
