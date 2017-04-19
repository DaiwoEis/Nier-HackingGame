using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputDevice
{
    private readonly string NAME_PREFIX;

    private Dictionary<Type, IButton> _buttons = new Dictionary<Type, IButton>();

    private Dictionary<Type, IAxis> _axises = new Dictionary<Type, IAxis>();

    protected InputDevice()
    {
        string typeName = GetType().ToString();
        NAME_PREFIX = typeName.Substring(0, typeName.Length - 6);
    }

    public void CreateButtons(IEnumerable<string> buttonNames)
    {
        foreach (var buttonName in buttonNames)
        {
            Type type = Type.GetType(NAME_PREFIX + buttonName);
            if (type == null)
            {
                Debug.LogError("The project dont has " + NAME_PREFIX + buttonName + " class");
            }
            else
            {
                _buttons.Add(type.BaseType, (IButton)Activator.CreateInstance(type));
            }
        }
    }

    public void CreateAxises(IEnumerable<string> directions)
    {
        foreach (var directionName in directions)
        {
            Type type = Type.GetType(NAME_PREFIX + directionName);
            if (type == null)
            {
                Debug.LogError("The project dont has " + NAME_PREFIX + directionName + " class");
            }
            else
            {
                _axises.Add(type.BaseType, (IAxis)Activator.CreateInstance(type));
            }
        }
    }

    public IButton GetButton<T>() where T : IButton
    {
        if (_buttons.ContainsKey(typeof(T)))
        {
            return _buttons[typeof(T)];
        }

        Debug.LogError(string.Format("The {0} device dont has {1}", NAME_PREFIX, typeof(T)));
        return null;
    }

    public IAxis GetAxis<T>() where T : IAxis
    {
        if (_axises.ContainsKey(typeof(T)))
        {
            return _axises[typeof(T)];
        }

        Debug.LogError(string.Format("The {0} device dont has {1}", NAME_PREFIX, typeof(T)));
        return null;
    }

    public void Update()
    {
        foreach (var button in _buttons.Values)
        {
            button.Update();
        }

        foreach (var direction in _axises.Values)
        {
            direction.Update();
        }
    }

    public abstract void TestChangeDevice(InputController inputController);
}
