using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public event Action onSpawn = null;

    public event Action onDestroy = null;

    public bool spawned { get; protected set; }

    public bool destroyed { get; protected set; }

    [SerializeField]
    private bool _isTemplate = false;
    public bool isTemplate { get { return _isTemplate; } }

    [SerializeField]
    protected List<FunctionBehaviour> _functions = null;    

    public virtual void OnSpawn()
    {
#if DEBUG_SCRIPT
        Debug.Log("Spawn " + gameObject.name);
#endif        
        spawned = true;
        destroyed = false;
        TriggerOnSpawnEvent();
        
        GameStateController.instance.onGamePaused += PauseFunctions;
        GameStateController.instance.onGameResumed += ResuneFunctions;
    }

    public virtual void OnRelease()
    {
#if DEBUG_SCRIPT
        Debug.Log("Destroy " + gameObject.name);        
#endif
        spawned = false;
        destroyed = true;
        GameStateController.instance.onGamePaused -= PauseFunctions;
        GameStateController.instance.onGameResumed -= ResuneFunctions;

        StopAllCoroutines();

        TriggerOnDestroyEvent();
        onSpawn = null;
        onDestroy = null;
    }

    protected virtual void Awake()
    {
        foreach (var function in GetComponentsInChildren<FunctionBehaviour>())
            _functions.Add(function);
    }

    public void TriggerOnSpawnEvent()
    {
        if (onSpawn != null) onSpawn();
    }

    public void TriggerOnDestroyEvent()
    {
        if (onDestroy != null) onDestroy();
    }

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

    protected void BeginFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.Begin();
        }
    }

    protected void EndFunctions()
    {
        foreach (var functionBehaviour in _functions)
        {
            functionBehaviour.End();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up*0.5f, transform.position + Vector3.up * 0.5f + transform.forward*2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f + transform.forward * 2f, 0.3f);
    }

}