using UnityEngine;
using UnityEngine.InputSystem;
//using cowboy;
namespace player_controller {

    [RequireComponent(typeof(CharacterController))]

    public class PlayerController : MonoBehaviour
    {
        private int playerNumber;
        private float playerSpeed = 4.0f;
        private int score;
        //private CowBoy CowBoy = new CowBoy();
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float crouchHeight = 1f;
        private float standingHeight;
        private Vector2 movementInput = Vector2.zero;
        public bool jumped;
        private bool shoot;
        private bool crouch;
        private bool aboveObstacle;
        private bool sprint;
        [SerializeField] private GameObject playerObject;


        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            standingHeight = controller.height;

            if (transform.parent.gameObject.name == "PlayerParent1"){
                this.playerNumber = 1;
            } else if (transform.parent.gameObject.name == "PlayerParent2") {
                 this.playerNumber = 2;
            } else {
                 this.playerNumber = 100;
            }

             //TODO make function to choose character
             //ALED
        }
        public void OnShoot(InputAction.CallbackContext context)
        {
            shoot = context.action.triggered;


        }
        public void OnMove(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();


        }

        public void OnJump(InputAction.CallbackContext context)
        {
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

            Vector3 horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * this.getPlayerSpeed();
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
            }
            else
            {

                Ray ray = new Ray(transform.position, transform.up);
                if (!Physics.Raycast(ray, 2))
                {
                    playerScale.y = standingHeight;
                    aboveObstacle = false;

                } else{
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
                this.setPlayerSpeed(8.0f);
                //this.setPlayerSpeed(this.CowBoy.getSprintSpeed());
            }
            else
            {
                this.setPlayerSpeed(4.0f);
                //this.setPlayerSpeed(this.CowBoy.getWalkSpeed());
            }
        }
        public void ReturnToSpawn(){
            transform.position =  new Vector3(0,0,0);
            Physics.SyncTransforms();
        }
        public int getScore(){
                return this.score;
            }
        public void setScore(int score){
            this.score = score;
        }
        public int getPlayerNumber(){
                return this.playerNumber;
        }
        public float getPlayerSpeed(){
                return this.playerSpeed;
        }
        public void setPlayerSpeed(float playerSpeed){
            this.playerSpeed = playerSpeed;
        }
    }
}