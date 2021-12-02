// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c21ed6cf-1da9-4e85-8070-6609a264e7b5"",
            ""actions"": [
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""ad02d63c-0506-4976-98df-398c2627baf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""fc92462b-8d93-4676-8c1c-d6a1291d2251"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a59d748-470d-4742-bc21-cd32245a0c38"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""17a26cfb-ef85-417e-951b-4b896d46dcbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""f99a956d-8fa1-40ef-a35b-497dd7a00f8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f668cb99-d68b-43af-940d-8b471c825b64"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""3e34d69f-c12d-43b9-acfc-06534ede99b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackAnim"",
                    ""type"": ""Button"",
                    ""id"": ""27704db5-6fbb-4c0a-b6d3-49f1052f1030"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetScenery"",
                    ""type"": ""Button"",
                    ""id"": ""c0dba31b-fa82-466c-abfb-0fabd0c33ac2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61872b3e-d2c0-42df-b75d-2c4b5542c227"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3107dd5b-733e-4db9-a610-c5e93fa4c31b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44fd88c2-4e5c-4739-a8fb-9abd3f434568"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d528bf-7307-45d3-84f7-12b093945a1c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ebd9313-47c3-4215-af39-b91facab9c07"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""PC_Movement"",
                    ""id"": ""fe821bc8-535f-47e1-8ed6-3129289c11a4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""72c95560-2eda-4782-9e62-698170792052"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50014da7-964f-4942-a166-61a451298581"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3c8ebade-56ad-4e34-8103-35af4c2dcacd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""085b3c9f-2e89-4667-8d03-c18c0c8050f4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b68a19dd-af8f-4719-a94c-e791ca1f63e2"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10be7e5a-dff6-44b1-9f3d-b105392a43dc"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackAnim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14e47ee6-b12a-499e-b102-8a8283b96ab3"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetScenery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC_Inputs"",
            ""bindingGroup"": ""PC_Inputs"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftButton = m_Player.FindAction("LeftButton", throwIfNotFound: true);
        m_Player_RightButton = m_Player.FindAction("RightButton", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_CameraMovement = m_Player.FindAction("CameraMovement", throwIfNotFound: true);
        m_Player_Back = m_Player.FindAction("Back", throwIfNotFound: true);
        m_Player_BackAnim = m_Player.FindAction("BackAnim", throwIfNotFound: true);
        m_Player_ResetScenery = m_Player.FindAction("ResetScenery", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftButton;
    private readonly InputAction m_Player_RightButton;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_CameraMovement;
    private readonly InputAction m_Player_Back;
    private readonly InputAction m_Player_BackAnim;
    private readonly InputAction m_Player_ResetScenery;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftButton => m_Wrapper.m_Player_LeftButton;
        public InputAction @RightButton => m_Wrapper.m_Player_RightButton;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @CameraMovement => m_Wrapper.m_Player_CameraMovement;
        public InputAction @Back => m_Wrapper.m_Player_Back;
        public InputAction @BackAnim => m_Wrapper.m_Player_BackAnim;
        public InputAction @ResetScenery => m_Wrapper.m_Player_ResetScenery;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftButton;
                @LeftButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftButton;
                @LeftButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftButton;
                @RightButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightButton;
                @RightButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightButton;
                @RightButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightButton;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @CameraMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraMovement;
                @Back.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @BackAnim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackAnim;
                @BackAnim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackAnim;
                @BackAnim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackAnim;
                @ResetScenery.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetScenery;
                @ResetScenery.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetScenery;
                @ResetScenery.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetScenery;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftButton.started += instance.OnLeftButton;
                @LeftButton.performed += instance.OnLeftButton;
                @LeftButton.canceled += instance.OnLeftButton;
                @RightButton.started += instance.OnRightButton;
                @RightButton.performed += instance.OnRightButton;
                @RightButton.canceled += instance.OnRightButton;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @BackAnim.started += instance.OnBackAnim;
                @BackAnim.performed += instance.OnBackAnim;
                @BackAnim.canceled += instance.OnBackAnim;
                @ResetScenery.started += instance.OnResetScenery;
                @ResetScenery.performed += instance.OnResetScenery;
                @ResetScenery.canceled += instance.OnResetScenery;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PC_InputsSchemeIndex = -1;
    public InputControlScheme PC_InputsScheme
    {
        get
        {
            if (m_PC_InputsSchemeIndex == -1) m_PC_InputsSchemeIndex = asset.FindControlSchemeIndex("PC_Inputs");
            return asset.controlSchemes[m_PC_InputsSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLeftButton(InputAction.CallbackContext context);
        void OnRightButton(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnBackAnim(InputAction.CallbackContext context);
        void OnResetScenery(InputAction.CallbackContext context);
    }
}
