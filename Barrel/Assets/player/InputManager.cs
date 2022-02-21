using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    PlayerController controls;
    PlayerController.GroundMovementActions groundMovement;
    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake ()
    {
        controls = new PlayerController();
        groundMovement = controls.GroundMovement;
        groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();
        groundMovement.Crouch.performed += _ => movement.OnCrouchPressed();
        groundMovement.Run.performed += _ => movement.OnRunPressed();
        groundMovement.Run.canceled += _ => movement.OnRunNotPressed();

        groundMovement.JoystickX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.JoystickY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable() {
        controls.Enable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);

    }
}
