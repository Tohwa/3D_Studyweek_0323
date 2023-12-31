using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTriggerActions : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _player;

    [Header("Components")]
    public Rigidbody _boatRB;

    [Header("Floats")]
    public float speed;

    [Header("Bools")]
    public bool startTimer;


    #endregion

    private void Start()
    {
        if(_player.transform.parent != null)
        {
            _player.GetComponent<Rigidbody>().isKinematic = true;
        }
        _boatRB.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider cldr)
    {
        if (cldr.CompareTag("endPoint"))
        {
            startTimer = true;

            _boatRB.velocity = Vector3.zero;
        }

        if(cldr.CompareTag("startPoint") && GameManager.Instance.winCondition)
        {
            GameManager.Instance.gameUI.ActivateWinText();
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit(Collider cldr)
    {
        if (cldr.CompareTag("Player"))
        {
            _player.transform.parent = null;
            _player.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
