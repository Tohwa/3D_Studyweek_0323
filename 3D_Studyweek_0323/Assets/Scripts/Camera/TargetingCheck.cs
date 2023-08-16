using UnityEngine;
using UnityEngine.InputSystem;

public class TargetingCheck : MonoBehaviour
{
    [SerializeField] private GameObject redObj;
    [SerializeField] private GameObject blueObj;
    [SerializeField] private GameObject yellowObj;
    [SerializeField] private Transform _objectHolder;

    Rigidbody grabbedRB;

    private void Update()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(_objectHolder.transform.position);
        }
    }

    public void OnInteractHit(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(grabbedRB)
            {
                grabbedRB.GetComponent<Collider>().enabled = true;
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;

                Physics.Raycast(transform.position, transform.forward, out hit, 3);
                if (hit.collider)
                {
                    if (hit.transform.tag == "inter" && GameManager.Instance.objectiveOne == hit.transform.name)
                    {
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                        grabbedRB.GetComponent<Collider>().enabled = false;
                        GameManager.Instance.gameUI.SetObjectiveFound(); //added by finn

                        if (grabbedRB)
                        {
                            grabbedRB.isKinematic = true;
                        }
                    }
                }
            }            
        }
    }
}
