using System.Collections;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T instance { get { return _instance; } } 

    public static void Create()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
            }

            _instance.OnCreate();
        }
    }


    public static IEnumerator _Release()
    {
        yield return _instance._OnRelease();
        _instance = null;
    }

    protected virtual void OnCreate()
    {
        //Debug.Log("Create " + instance.gameObject.name);
    }

    protected virtual IEnumerator _OnRelease()
    {
        //Debug.Log("Release " + instance.gameObject.name);
        yield break;
    }
}
