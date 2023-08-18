// GENERATED AUTOMATICALLY FROM 'Assets/Input/CraneControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CraneControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CraneControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CraneControls"",
    ""maps"": [
        {
            ""name"": ""Crane_Actions"",
            ""id"": ""8f0ef537-74a9-4929-8d2e-4b5ad354d735"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0a960919-e98c-4992-855b-cf20ac7882c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop_Crane"",
                    ""type"": ""Button"",
                    ""id"": ""1e6106e9-80fd-414c-9b04-12f4d1cab7a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector (Keyboard)"",
                    ""id"": ""0ae285e2-311f-4299-9dbf-87cdcd16d6a7"",
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
                    ""id"": ""4607e020-c8b3-4113-af2d-c40dcf4e53d9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""05af9f62-1a8d-4442-9e50-16bad044a262"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8321e2e8-e02c-4a45-a0f9-5455830bf144"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2217c7d7-ddd3-4bb8-92b8-09ed4c5c04b1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c1edd9e8-14d2-4ac9-9370-5a9250a085dc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""71c70101-c90b-4b88-ad48-37501fc3ebea"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1ea351cc-dad7-4edc-bf31-09ffe5c33f53"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7aed6418-871a-430c-a611-053be4915c44"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2a3c1b16-2d1c-4707-aa23-24f2ed04f50e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector (Gamepad)"",
                    ""id"": ""c35e35d8-f0f9-492f-ad28-7ffd94f7bc6a"",
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
                    ""id"": ""41fd7f77-2aae-4f4d-aba6-8ada95552606"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9437a18e-ac18-495f-9c61-b275c53270ef"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49cce7eb-7a8a-4fe1-acce-48cd686ebf6e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc41c64c-6953-42cd-9e95-2071dcb94386"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""58d3603f-ac19-43d7-8516-4d46721bb1e8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drop_Crane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""148e001b-c73c-4555-8691-2b97f504eeea"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drop_Crane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Crane_Actions
        m_Crane_Actions = asset.FindActionMap("Crane_Actions", throwIfNotFound: true);
        m_Crane_Actions_Movement = m_Crane_Actions.FindAction("Movement", throwIfNotFound: true);
        m_Crane_Actions_Drop_Crane = m_Crane_Actions.FindAction("Drop_Crane", throwIfNotFound: true);
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

    // Crane_Actions
    private readonly InputActionMap m_Crane_Actions;
    private ICrane_ActionsActions m_Crane_ActionsActionsCallbackInterface;
    private readonly InputAction m_Crane_Actions_Movement;
    private readonly InputAction m_Crane_Actions_Drop_Crane;
    public struct Crane_ActionsActions
    {
        private @CraneControls m_Wrapper;
        public Crane_ActionsActions(@CraneControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Crane_Actions_Movement;
        public InputAction @Drop_Crane => m_Wrapper.m_Crane_Actions_Drop_Crane;
        public InputActionMap Get() { return m_Wrapper.m_Crane_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Crane_ActionsActions set) { return set.Get(); }
        public void SetCallbacks(ICrane_ActionsActions instance)
        {
            if (m_Wrapper.m_Crane_ActionsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnMovement;
                @Drop_Crane.started -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnDrop_Crane;
                @Drop_Crane.performed -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnDrop_Crane;
                @Drop_Crane.canceled -= m_Wrapper.m_Crane_ActionsActionsCallbackInterface.OnDrop_Crane;
            }
            m_Wrapper.m_Crane_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Drop_Crane.started += instance.OnDrop_Crane;
                @Drop_Crane.performed += instance.OnDrop_Crane;
                @Drop_Crane.canceled += instance.OnDrop_Crane;
            }
        }
    }
    public Crane_ActionsActions @Crane_Actions => new Crane_ActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ICrane_ActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDrop_Crane(InputAction.CallbackContext context);
    }
}
