using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public event Action onSpawn = null;

    public event Action onDestroy = null;

    protected bool _worked = false;

    protected FunctionBehaviour[] _functions = null;

    protected virtual void Awake()
    {
        _functions = GetComponents<FunctionBehaviour>();
    }

    public virtual void Spawn()
    {
        TriggerOnSpawnEvent();
        _worked = true;
    }

    public virtual void Destroy()
    {
        _worked = false;
        TriggerOnDestroyEvent();
    }

    protected void TriggerOnSpawnEvent()
    {
        if (onSpawn != null) onSpawn();
    }

    protected void TriggerOnDestroyEvent()
    {
        if (onDestroy != null) onDestroy();
    }

    protected void PauseFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.Pause();
        }
    }

    protected void ResuneFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.Resume();
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
