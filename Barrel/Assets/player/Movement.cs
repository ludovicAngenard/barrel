using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;
    [SerializeField] float jumpHeight = 3.5f;
    bool jump, crouch;
    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    public void ReceiveInput (Vector2 horizontalInput){
        this.horizontalInput = horizontalInput;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded){
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x +
        transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump){
            if (isGrounded){
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }
        //  if (crouch){
        //     if (isGrounded){
        //         Debug.Log(controller.height);
        //         controller.height = 0.75f;
        //         Debug.Log(controller.height);
        //     }
        //     crouch = false;
        //     controller.height = 1.5f;
        // }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

    }

    public void OnJumpPressed(){
        jump = true;
    }

    public void OnCrouchPressed(){
        crouch = true;
    }
}
