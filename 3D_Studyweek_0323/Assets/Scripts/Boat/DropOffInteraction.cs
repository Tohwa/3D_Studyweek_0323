using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffInteraction : MonoBehaviour
{
    private void OnTriggerStay(Collider cldr)
    {
        if (cldr.CompareTag("inter"))
        {
            cldr.gameObject.SetActive(false);
            if(GameManager.Instance.itemlist.Count > 0)
            {
                GameManager.Instance.SetObjToFind();
                //added by finn
                GameManager.Instance.gameUI.UpdateItemList();
            }            
        }
    }
}
