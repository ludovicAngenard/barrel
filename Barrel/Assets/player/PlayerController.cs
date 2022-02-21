// GENERATED AUTOMATICALLY FROM 'Assets/player/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""GroundMovement"",
            ""id"": ""1f7bd10b-171c-4016-91e5-e97e9022b732"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb5a82ea-c6b0-4f45-95fe-df20915465f9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cfae0ead-4745-4e6a-8899-7e6c72dd5c96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4f488f78-fffc-4f25-945e-3b85268f318c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d74c7dbc-6823-4aa5-a3b6-ffa86ffa9bb1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""86a17e81-dfdf-4ced-a715-306de447e9d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""678513f2-983b-4594-bc6b-c229c1c1d2b5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7262f84a-6495-419e-8244-ceabd1ecf8bf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e6e539-229f-4f69-ac29-86bd5d5d9ae5"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbe8b5e8-1c09-4096-981a-8da81096d69f"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfb228d3-736b-41ff-bc62-9013d105f9b0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GroundMovement
        m_GroundMovement = asset.FindActionMap("GroundMovement", throwIfNotFound: true);
        m_GroundMovement_Move = m_GroundMovement.FindAction("Move", throwIfNotFound: true);
        m_GroundMovement_Jump = m_GroundMovement.FindAction("Jump", throwIfNotFound: true);
        m_GroundMovement_JoystickX = m_GroundMovement.FindAction("JoystickX", throwIfNotFound: true);
        m_GroundMovement_JoystickY = m_GroundMovement.FindAction("JoystickY", throwIfNotFound: true);
        m_GroundMovement_Crouch = m_GroundMovement.FindAction("Crouch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GroundMovement
    private readonly InputActionMap m_GroundMovement;
    private IGroundMovementActions m_GroundMovementActionsCallbackInterface;
    private readonly InputAction m_GroundMovement_Move;
    private readonly InputAction m_GroundMovement_Jump;
    private readonly InputAction m_GroundMovement_JoystickX;
    private readonly InputAction m_GroundMovement_JoystickY;
    private readonly InputAction m_GroundMovement_Crouch;
    public struct GroundMovementActions
    {
        private @PlayerController m_Wrapper;
        public GroundMovementActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GroundMovement_Move;
        public InputAction @Jump => m_Wrapper.m_GroundMovement_Jump;
        public InputAction @JoystickX => m_Wrapper.m_GroundMovement_JoystickX;
        public InputAction @JoystickY => m_Wrapper.m_GroundMovement_JoystickY;
        public InputAction @Crouch => m_Wrapper.m_GroundMovement_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_GroundMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundMovementActions set) { return set.Get(); }
        public void SetCallbacks(IGroundMovementActions instance)
        {
            if (m_Wrapper.m_GroundMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @JoystickX.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickX;
                @JoystickX.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickX;
                @JoystickX.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickX;
                @JoystickY.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickY;
                @JoystickY.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickY;
                @JoystickY.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJoystickY;
                @Crouch.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_GroundMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JoystickX.started += instance.OnJoystickX;
                @JoystickX.performed += instance.OnJoystickX;
                @JoystickX.canceled += instance.OnJoystickX;
                @JoystickY.started += instance.OnJoystickY;
                @JoystickY.performed += instance.OnJoystickY;
                @JoystickY.canceled += instance.OnJoystickY;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public GroundMovementActions @GroundMovement => new GroundMovementActions(this);
    public interface IGroundMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJoystickX(InputAction.CallbackContext context);
        void OnJoystickY(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
