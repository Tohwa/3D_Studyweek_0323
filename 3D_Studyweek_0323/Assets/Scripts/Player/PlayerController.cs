using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _target;

    [Header("Floats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayLength = 10f;

    [Header("Booleans")]
    [SerializeField] private bool grounded;

    [Header("Masks")]
    [SerializeField] private LayerMask groundLayers;

    private Vector2 movementInput;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        // Bewegung
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * moveSpeed * Time.deltaTime;
        movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;
        movement = Vector3.ClampMagnitude(movement, 1) * 3;
        _rb.MovePosition(transform.position + transform.TransformDirection(movement));

        RaycastHit hit;
        if (Physics.Raycast(
                        transform.position,
                        Vector2.down,
                        out hit,
                        rayLength,
                        groundLayers))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
            movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && grounded)
        {
            grounded = false;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
