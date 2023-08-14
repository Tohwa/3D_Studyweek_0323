using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetingCheck : MonoBehaviour
{
    #region Fields
    [SerializeField] private bool interact;
    #endregion

    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, transform.forward, out hit, 10);
        if (hit.collider)
        {
            if (hit.transform.tag == "" && interact)
            {
                
            }

        }
    }

    public void OnInteractHit(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            interact = true;
        }
    }
}
