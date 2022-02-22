using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform playerController;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;
    float yRotation = 0f;
    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY * 1.5f;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp); //bloquer l'angle à un maximum et un mini
        yRotation += mouseX / 9f;

        Vector3 targetRotationX = transform.eulerAngles;
        Vector3 targetRotationY = transform.eulerAngles;

        targetRotationX.x = xRotation;
        targetRotationY.y = yRotation;

        playerController.eulerAngles = targetRotationY;
        playerCamera.eulerAngles = targetRotationX;

    }
    public void MouseX(InputAction.CallbackContext context)
    {
       // jumped = context.ReadValue<bool>();
        mouseX = context.action.triggered;
    }
    public void MouseY(InputAction.CallbackContext context)
    {
        mouseY = context.ReadValue<Vector2>();

    }
}
