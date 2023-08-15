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
                        //hit.transform.gameObject.SetActive(false);
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();

                        if (grabbedRB)
                        {
                            grabbedRB.isKinematic = true;
                        }
                    }
                    else if (hit.transform.tag == "NPC")
                    {
                        ClearObjective();
                    }

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
