using UnityEngine;
using UnityEngine.InputSystem;
using NamespaceSplitScreen;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float playerSpeed = 2.0f;
    private float sprintSpeed = 8.0f;
    private float walkSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private float crouchHeight = 1f;
    private float standingHeight;
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private bool crouch = false;
    private bool aboveObstacle = false;

    private bool sprint = false;
    [SerializeField] private GameObject playerObject;

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

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (aboveObstacle){
            CheckCrouch();
        }
    }

    void CheckCrouch()
    {
        Vector3 playerScale = transform.localScale;

        if (crouch)
        {
            playerScale.y = crouchHeight;
            aboveObstacle = true;
        }
        else
        {

            Ray ray = new Ray(transform.position, transform.up);
            if (!Physics.Raycast(ray, 2))
            {
                playerScale.y = standingHeight;
                aboveObstacle = true;
                Debug.Log("ca touche");
            }


        }
        transform.localScale = playerScale;
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