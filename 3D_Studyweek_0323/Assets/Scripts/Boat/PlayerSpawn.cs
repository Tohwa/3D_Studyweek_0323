using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerSpawn : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _player;

    [Header("Components")]
    [SerializeField] private Rigidbody _boatRB;

    [Header("Scripts")]
    [SerializeField] BoatTriggerActions _boatTriggerActions;
    #endregion

    private void OnTriggerEnter(Collider cldr)
    {
        if (cldr.CompareTag("Player") && GameManager.Instance.itemlist.Count == 0)
        {
            _player.transform.parent = transform;
            _player.GetComponent<Rigidbody>().isKinematic = true;
            _boatRB.velocity = Vector3.back * _boatTriggerActions.speed;
            GameManager.Instance.winCondition = true;
        }
    }
}
