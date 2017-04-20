using System;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public event Action onSpawn = null;

    public event Action onDestroy = null;

    protected FunctionBehaviour[] _functions = null;

    protected virtual void Awake()
    {
        _functions = GetComponents<FunctionBehaviour>();
    }

    public void Spawn()
    {        
        WhenSpawn();
        if (onSpawn != null) onSpawn();
    }

    public void Destroy()
    {
        WhenDestory();
        if (onDestroy != null) onDestroy();
    }

    protected virtual void WhenSpawn() { }

    protected virtual void WhenDestory() { }

    protected void PauseFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.pause = true;
        }
    }

    protected void ResuneFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.pause = false;
        }
    }

    protected void ExecuteFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.Execute();
        }
    }

    protected void EndFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.End();
        }
    }
}