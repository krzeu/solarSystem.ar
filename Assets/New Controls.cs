//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/New Controls.inputactions
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

public partial class @NewControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""sensor"",
            ""id"": ""47a16438-e74c-448a-8a54-a3c8f359c264"",
            ""actions"": [
                {
                    ""name"": ""acelator"",
                    ""type"": ""Value"",
                    ""id"": ""54f00155-3fca-4959-a388-a98ac2110edc"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4e2c37c-690f-4bcb-9034-3db558cb2a19"",
                    ""path"": ""<Accelerometer>/acceleration"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""acelator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3459d28-e1a1-45bb-8edb-8311d0278d9f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""acelator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // sensor
        m_sensor = asset.FindActionMap("sensor", throwIfNotFound: true);
        m_sensor_acelator = m_sensor.FindAction("acelator", throwIfNotFound: true);
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

    // sensor
    private readonly InputActionMap m_sensor;
    private List<ISensorActions> m_SensorActionsCallbackInterfaces = new List<ISensorActions>();
    private readonly InputAction m_sensor_acelator;
    public struct SensorActions
    {
        private @NewControls m_Wrapper;
        public SensorActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @acelator => m_Wrapper.m_sensor_acelator;
        public InputActionMap Get() { return m_Wrapper.m_sensor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SensorActions set) { return set.Get(); }
        public void AddCallbacks(ISensorActions instance)
        {
            if (instance == null || m_Wrapper.m_SensorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SensorActionsCallbackInterfaces.Add(instance);
            @acelator.started += instance.OnAcelator;
            @acelator.performed += instance.OnAcelator;
            @acelator.canceled += instance.OnAcelator;
        }

        private void UnregisterCallbacks(ISensorActions instance)
        {
            @acelator.started -= instance.OnAcelator;
            @acelator.performed -= instance.OnAcelator;
            @acelator.canceled -= instance.OnAcelator;
        }

        public void RemoveCallbacks(ISensorActions instance)
        {
            if (m_Wrapper.m_SensorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISensorActions instance)
        {
            foreach (var item in m_Wrapper.m_SensorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SensorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SensorActions @sensor => new SensorActions(this);
    public interface ISensorActions
    {
        void OnAcelator(InputAction.CallbackContext context);
    }
}
