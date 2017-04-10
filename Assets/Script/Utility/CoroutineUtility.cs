using System;
using System.Collections;
using UnityEngine;

public class CoroutineUtility : MonoBehaviour
{
    private static CoroutineUtility _instance = null;

    private static CoroutineUtility instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoroutineUtility>();
            }

            if (_instance == null)
            {
                _instance = new GameObject("Dont Destroy").AddComponent<CoroutineUtility>();                
            }

            DontDestroyOnLoad(_instance.gameObject);

            return _instance;
        }
    }

    public static Coroutine UStartCoroutine(IEnumerator routine)
    {
        return instance.StartCoroutine(routine);
    }

    public static Coroutine UStartCoroutine(float time, Action action)
    {
        if (time.Equals(0f))
        {
            action();
            return null;
        }
        return instance.StartCoroutine(_TimeAction(time, action));
    }

    public static Coroutine UStartCoroutineReal(float time, Action action)
    {
        if (time.Equals(0f))
        {
            action();
            return null;
        }
        return instance.StartCoroutine(_TimeActionReal(time, action));
    }

    private static IEnumerator _TimeAction(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        if (action != null)
        {
            action();
        }
    }

    private static IEnumerator _TimeActionReal(float time, Action action)
    {
        yield return new WaitForSecondsRealtime(time);
        if (action != null)
        {
            action();
        }
    }

    public static void UStopCoroutine(Coroutine routine)
    {
        if (instance != null)
            instance.StopCoroutine(routine);
    }

    public static void UStopAllCoroutines()
    {
        instance.StopAllCoroutines();
    }

    private void OnDestroy()
    {
        if (_instance != null)
        {
            _instance.StopAllCoroutines();
            _instance = null;
        }        
    }
}
