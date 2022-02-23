using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    private float sprintSpeed = 4.0f;
    private float walkSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private float crouchHeight = 0.5f;
    private float standingHeight;
    //private float timeToCrouch = 0.25f;
    //private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    //private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching;
    //private bool duringCrouchAnimation;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private bool crouch = false;

    private bool sprint = false;





    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        standingHeight = controller.height;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // jumped = context.ReadValue<bool>();
        jumped = context.action.triggered;
    }

    

    public void OnCrouch(InputAction.CallbackContext context)
    {
        crouch = context.action.triggered;


        CheckCrouch();


    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprint = context.action.triggered;
        Debug.Log(sprint);
        Debug.Log("------------");
        CheckSprint();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * playerSpeed;
        controller.Move(horizontalVelocity * Time.deltaTime);

      // Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
      // controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
       // {
       //     gameObject.transform.forward = move;
       // }

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }


        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        
    }


    void CheckCrouch()
    {
        if (crouch == true)
        {
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = standingHeight;
        }
    }


    void CheckSprint()
    {
        if (sprint)
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }
    }
    
}