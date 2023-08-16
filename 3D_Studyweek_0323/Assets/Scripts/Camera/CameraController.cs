using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InputSource
{
    None,
    Mouse,
    Controller
}

public class CameraController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody _boatRB;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float controllerSensitivity;

    private InputSource currentInputSource = InputSource.None;

    private Vector2 cameraInput;
    private Vector3 angle;
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(_boatRB.velocity.magnitude < 0.1f)
        {
            switch (currentInputSource)
            {
                case InputSource.Mouse:
                    angle.x += -cameraInput.y * Time.deltaTime * mouseSensitivity;
                    angle.y += cameraInput.x * Time.deltaTime * mouseSensitivity;
                    break;

                case InputSource.Controller:
                    angle.x += -cameraInput.y * Time.deltaTime * controllerSensitivity;
                    angle.y += cameraInput.x * Time.deltaTime * controllerSensitivity;
                    break;

                case InputSource.None:
                    // No input, don't update camera angles
                    break;
            }

            angle.x = Mathf.Clamp(angle.x, -85, 85);
            transform.eulerAngles = angle;
        }        
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        cameraInput = ctx.ReadValue<Vector2>();

        if (ctx.action.activeControl.displayName == "Mouse")
        {
            currentInputSource = InputSource.Mouse;
        }
        else
        {
            currentInputSource = InputSource.Controller;
        }
    }
}
