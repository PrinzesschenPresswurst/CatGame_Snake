//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerIputActions.inputactions
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

public partial class @PlayerIputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerIputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerIputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cb310b77-b0a1-4b82-a180-51c9c9fbf9a1"",
            ""actions"": [
                {
                    ""name"": ""Swipe"",
                    ""type"": ""Value"",
                    ""id"": ""b66e707c-787f-4ff3-ba39-f3aaa06d3b86"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""aed8d52a-48d8-43ec-8fdf-22c7ff0df9a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18e3ac15-8afe-4b0e-a16f-3de4f944affd"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f059edf-3a25-4ab2-90c0-c30b8d43fcf3"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Swipe = m_Player.FindAction("Swipe", throwIfNotFound: true);
        m_Player_Touch = m_Player.FindAction("Touch", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Swipe;
    private readonly InputAction m_Player_Touch;
    public struct PlayerActions
    {
        private @PlayerIputActions m_Wrapper;
        public PlayerActions(@PlayerIputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Swipe => m_Wrapper.m_Player_Swipe;
        public InputAction @Touch => m_Wrapper.m_Player_Touch;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Swipe.started += instance.OnSwipe;
            @Swipe.performed += instance.OnSwipe;
            @Swipe.canceled += instance.OnSwipe;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Swipe.started -= instance.OnSwipe;
            @Swipe.performed -= instance.OnSwipe;
            @Swipe.canceled -= instance.OnSwipe;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnSwipe(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
}
