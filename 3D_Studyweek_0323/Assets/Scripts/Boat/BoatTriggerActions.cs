using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTriggerActions : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private Rigidbody _boatRB;
    [SerializeField] private Transform _npcTransform;

    [Header("Floats")]
    [SerializeField] private float speed;

    private Vector3 npcLocalOffset;

    #endregion

    private void Start()
    {
        _boatRB.velocity = transform.forward * speed;

        npcLocalOffset = _npcTransform.localPosition;
    }

    private void Update()
    {
        _npcTransform.localPosition = npcLocalOffset;
    }

    private void OnTriggerEnter(Collider cldr)
    {
        if (cldr.CompareTag("endPoint"))
        {
            _boatRB.velocity = Vector3.zero;
        }
    }
}
