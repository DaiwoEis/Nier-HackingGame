using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class InputConroller : MonoBehaviour
{
    private InputDevice _currDevice = null;

    public InputDevice currDevice { get { return _currDevice; } }

    private Dictionary<Type, InputDevice> _devices = new Dictionary<Type, InputDevice>();

    private void Awake()
    { 
        Init();
    }

    private void Init()
    {
        _devices.Add(typeof(KeyboardDevice), new KeyboardDevice());
        _devices.Add(typeof(ControllerDevice), new ControllerDevice());

        string[] buttonNames = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsAbstract && type.GetInterfaces().Contains(typeof(IButton)))
            .Select(type => type.Name).ToArray();

        string[] directionNames = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsAbstract && type.GetInterfaces().Contains(typeof(IAxis)))
            .Select(type => type.Name).ToArray();

        foreach (var inputDevice in _devices.Values)
        {
            inputDevice.CreateButtons(buttonNames);
            inputDevice.CreateDirections(directionNames);
        }

        ChangeDevice<KeyboardDevice>();
    }

    private void Update()
    {
        _currDevice.Update();
    }

    private void OnGUI()
    {
        _currDevice.TestChangeDevice(this);
    }

    public bool GetButtonDown<T>() where T : IButton
    {
        return _currDevice.GetButton<T>().Down();
    }

    public bool GetButtonUp<T>() where T : IButton
    {
        return _currDevice.GetButton<T>().Up();
    }

    public bool GetButtonHold<T>() where T : IButton
    {
        return _currDevice.GetButton<T>().Hold();
    }

    public Vector3 GetAxis<T>() where T : IAxis
    {
        return _currDevice.GetAxis<T>().Axis();
    }

    public void ChangeDevice<T>() where T : InputDevice
    {
        _currDevice = _devices[typeof(T)];
        Debug.Log(_currDevice);
    }
}