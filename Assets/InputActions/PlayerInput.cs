//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActions/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ArcadeFighter
{
    public partial class @PlayerInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""LeftPlayer"",
            ""id"": ""0f7377b8-74c6-4831-b340-270f2b9aff4b"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5a183332-1928-47b7-b8ac-bf0056f8be6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""6a10a2de-b3ed-4b26-bcf9-1361e4a69e82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""244ee787-54aa-4908-9884-344380d9dcca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""82b2ae18-8a7d-49fb-8e45-4a286ad88a57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Evade"",
                    ""type"": ""Button"",
                    ""id"": ""57db2446-04b0-4311-8a0d-535235e287e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a6a16110-5435-4346-a1e6-a6c11b39caa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintForward"",
                    ""type"": ""Button"",
                    ""id"": ""1d9e2df3-30a9-4f07-bf14-9f691e1d5efc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2022d2ce-dea9-4b6d-8975-5ae43b472d8a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2662715f-b7a3-41da-ba0b-b2a5ab09fe34"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ca02eb9-f8a9-4915-a235-8f49a6611562"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""516ccc66-bd03-44fc-8eab-fed680c0427a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e418eb63-2185-4f9f-af6a-3af86889cbb1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Evade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""524f052a-c525-46ea-b0bf-8ce89d9bbb3a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34843b63-5a15-442e-84ec-06865b7e089d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RightPlayer"",
            ""id"": ""3c3aac54-b504-4d9d-aa62-646e7a24c1b8"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b80223f6-c316-464d-b76b-387bb7ea1508"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""0f3b923d-0404-4172-aab3-ea4f791f38b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""a695e08a-0634-4024-ac95-422d8fa5bb74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""f46cf28d-9b5b-4d58-ba71-d6cb2327d783"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Evade"",
                    ""type"": ""Button"",
                    ""id"": ""361313a5-b024-4e94-b1c6-1a9fc3949ec8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3cf99046-ce4b-4e37-a7ae-d65287b26607"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintForward"",
                    ""type"": ""Button"",
                    ""id"": ""4ef5edd1-e8b9-421f-b0b5-0296410085d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da15e3b7-534d-4b07-9fd8-3e28874cfec8"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee59f0b8-f957-40fa-b528-945422dd3288"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d889b10-fa50-47e8-bce9-52cf3bb5de4b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab572bc-5c6e-4e3f-8d2a-5bf9ea8d5539"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e6c6ef-0d48-4fae-b505-db72bc62e772"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Evade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ede7cc49-1d98-41a5-a9b7-eff13651b855"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""030484f9-7592-453a-b752-011ae1321c6a"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // LeftPlayer
            m_LeftPlayer = asset.FindActionMap("LeftPlayer", throwIfNotFound: true);
            m_LeftPlayer_MoveLeft = m_LeftPlayer.FindAction("MoveLeft", throwIfNotFound: true);
            m_LeftPlayer_MoveRight = m_LeftPlayer.FindAction("MoveRight", throwIfNotFound: true);
            m_LeftPlayer_Attack = m_LeftPlayer.FindAction("Attack", throwIfNotFound: true);
            m_LeftPlayer_Block = m_LeftPlayer.FindAction("Block", throwIfNotFound: true);
            m_LeftPlayer_Evade = m_LeftPlayer.FindAction("Evade", throwIfNotFound: true);
            m_LeftPlayer_Jump = m_LeftPlayer.FindAction("Jump", throwIfNotFound: true);
            m_LeftPlayer_SprintForward = m_LeftPlayer.FindAction("SprintForward", throwIfNotFound: true);
            // RightPlayer
            m_RightPlayer = asset.FindActionMap("RightPlayer", throwIfNotFound: true);
            m_RightPlayer_MoveLeft = m_RightPlayer.FindAction("MoveLeft", throwIfNotFound: true);
            m_RightPlayer_MoveRight = m_RightPlayer.FindAction("MoveRight", throwIfNotFound: true);
            m_RightPlayer_Attack = m_RightPlayer.FindAction("Attack", throwIfNotFound: true);
            m_RightPlayer_Block = m_RightPlayer.FindAction("Block", throwIfNotFound: true);
            m_RightPlayer_Evade = m_RightPlayer.FindAction("Evade", throwIfNotFound: true);
            m_RightPlayer_Jump = m_RightPlayer.FindAction("Jump", throwIfNotFound: true);
            m_RightPlayer_SprintForward = m_RightPlayer.FindAction("SprintForward", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // LeftPlayer
        private readonly InputActionMap m_LeftPlayer;
        private List<ILeftPlayerActions> m_LeftPlayerActionsCallbackInterfaces = new List<ILeftPlayerActions>();
        private readonly InputAction m_LeftPlayer_MoveLeft;
        private readonly InputAction m_LeftPlayer_MoveRight;
        private readonly InputAction m_LeftPlayer_Attack;
        private readonly InputAction m_LeftPlayer_Block;
        private readonly InputAction m_LeftPlayer_Evade;
        private readonly InputAction m_LeftPlayer_Jump;
        private readonly InputAction m_LeftPlayer_SprintForward;
        public struct LeftPlayerActions
        {
            private @PlayerInput m_Wrapper;
            public LeftPlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveLeft => m_Wrapper.m_LeftPlayer_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_LeftPlayer_MoveRight;
            public InputAction @Attack => m_Wrapper.m_LeftPlayer_Attack;
            public InputAction @Block => m_Wrapper.m_LeftPlayer_Block;
            public InputAction @Evade => m_Wrapper.m_LeftPlayer_Evade;
            public InputAction @Jump => m_Wrapper.m_LeftPlayer_Jump;
            public InputAction @SprintForward => m_Wrapper.m_LeftPlayer_SprintForward;
            public InputActionMap Get() { return m_Wrapper.m_LeftPlayer; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LeftPlayerActions set) { return set.Get(); }
            public void AddCallbacks(ILeftPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_LeftPlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LeftPlayerActionsCallbackInterfaces.Add(instance);
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Evade.started += instance.OnEvade;
                @Evade.performed += instance.OnEvade;
                @Evade.canceled += instance.OnEvade;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @SprintForward.started += instance.OnSprintForward;
                @SprintForward.performed += instance.OnSprintForward;
                @SprintForward.canceled += instance.OnSprintForward;
            }

            private void UnregisterCallbacks(ILeftPlayerActions instance)
            {
                @MoveLeft.started -= instance.OnMoveLeft;
                @MoveLeft.performed -= instance.OnMoveLeft;
                @MoveLeft.canceled -= instance.OnMoveLeft;
                @MoveRight.started -= instance.OnMoveRight;
                @MoveRight.performed -= instance.OnMoveRight;
                @MoveRight.canceled -= instance.OnMoveRight;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Block.started -= instance.OnBlock;
                @Block.performed -= instance.OnBlock;
                @Block.canceled -= instance.OnBlock;
                @Evade.started -= instance.OnEvade;
                @Evade.performed -= instance.OnEvade;
                @Evade.canceled -= instance.OnEvade;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @SprintForward.started -= instance.OnSprintForward;
                @SprintForward.performed -= instance.OnSprintForward;
                @SprintForward.canceled -= instance.OnSprintForward;
            }

            public void RemoveCallbacks(ILeftPlayerActions instance)
            {
                if (m_Wrapper.m_LeftPlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILeftPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_LeftPlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LeftPlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LeftPlayerActions @LeftPlayer => new LeftPlayerActions(this);

        // RightPlayer
        private readonly InputActionMap m_RightPlayer;
        private List<IRightPlayerActions> m_RightPlayerActionsCallbackInterfaces = new List<IRightPlayerActions>();
        private readonly InputAction m_RightPlayer_MoveLeft;
        private readonly InputAction m_RightPlayer_MoveRight;
        private readonly InputAction m_RightPlayer_Attack;
        private readonly InputAction m_RightPlayer_Block;
        private readonly InputAction m_RightPlayer_Evade;
        private readonly InputAction m_RightPlayer_Jump;
        private readonly InputAction m_RightPlayer_SprintForward;
        public struct RightPlayerActions
        {
            private @PlayerInput m_Wrapper;
            public RightPlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveLeft => m_Wrapper.m_RightPlayer_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_RightPlayer_MoveRight;
            public InputAction @Attack => m_Wrapper.m_RightPlayer_Attack;
            public InputAction @Block => m_Wrapper.m_RightPlayer_Block;
            public InputAction @Evade => m_Wrapper.m_RightPlayer_Evade;
            public InputAction @Jump => m_Wrapper.m_RightPlayer_Jump;
            public InputAction @SprintForward => m_Wrapper.m_RightPlayer_SprintForward;
            public InputActionMap Get() { return m_Wrapper.m_RightPlayer; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RightPlayerActions set) { return set.Get(); }
            public void AddCallbacks(IRightPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_RightPlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_RightPlayerActionsCallbackInterfaces.Add(instance);
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Evade.started += instance.OnEvade;
                @Evade.performed += instance.OnEvade;
                @Evade.canceled += instance.OnEvade;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @SprintForward.started += instance.OnSprintForward;
                @SprintForward.performed += instance.OnSprintForward;
                @SprintForward.canceled += instance.OnSprintForward;
            }

            private void UnregisterCallbacks(IRightPlayerActions instance)
            {
                @MoveLeft.started -= instance.OnMoveLeft;
                @MoveLeft.performed -= instance.OnMoveLeft;
                @MoveLeft.canceled -= instance.OnMoveLeft;
                @MoveRight.started -= instance.OnMoveRight;
                @MoveRight.performed -= instance.OnMoveRight;
                @MoveRight.canceled -= instance.OnMoveRight;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Block.started -= instance.OnBlock;
                @Block.performed -= instance.OnBlock;
                @Block.canceled -= instance.OnBlock;
                @Evade.started -= instance.OnEvade;
                @Evade.performed -= instance.OnEvade;
                @Evade.canceled -= instance.OnEvade;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @SprintForward.started -= instance.OnSprintForward;
                @SprintForward.performed -= instance.OnSprintForward;
                @SprintForward.canceled -= instance.OnSprintForward;
            }

            public void RemoveCallbacks(IRightPlayerActions instance)
            {
                if (m_Wrapper.m_RightPlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IRightPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_RightPlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_RightPlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public RightPlayerActions @RightPlayer => new RightPlayerActions(this);
        public interface ILeftPlayerActions
        {
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnBlock(InputAction.CallbackContext context);
            void OnEvade(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprintForward(InputAction.CallbackContext context);
        }
        public interface IRightPlayerActions
        {
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnBlock(InputAction.CallbackContext context);
            void OnEvade(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprintForward(InputAction.CallbackContext context);
        }
    }
}
