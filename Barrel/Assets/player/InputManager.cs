using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Movement movement;
    PlayerController controls;
    PlayerController.GroundMovementActions groundMovement;
    Vector2 horizontalInput;

    private void Awake ()
    {
        controls = new PlayerController();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
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

    }
}
