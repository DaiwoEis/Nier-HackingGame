using System;
using System.Reflection;
using UnityEngine;

public class SingletonRoot : MonoBehaviour
{
    [SerializeField]
    private TextAsset _singletonConfig = null;

    private string CREATE = "Create";

    private string DESTROY = "Destroy";

    private void Awake()
    {
        string[] singletonNames = _singletonConfig.text.Split(',');
        for (int i = 0; i < singletonNames.Length; i++)
        {
            InvokeMethod(ref CREATE, singletonNames, i);
        }
    }

    private void OnDestroy()
    {
        string[] singletonNames = _singletonConfig.text.Split(',');
        for (int i = singletonNames.Length - 1; i >= 0; --i)
        {
            InvokeMethod(ref DESTROY, singletonNames, i);
        }
    }

    private static void InvokeMethod(ref string name, string[] singletonNames, int i)
    {
        Type type = Type.GetType(singletonNames[i]);

        if (type == null)
        {
            Debug.LogError(string.Format("type name: {0} is not validate", singletonNames[i]));
            return;
        }

        type.BaseType
            .GetMethod(name, BindingFlags.Static | BindingFlags.Public)
            .Invoke(null, null);
    }
}
