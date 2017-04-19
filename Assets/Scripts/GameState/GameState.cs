using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    protected GameStateController _stateController = null;

    [SerializeField]
    protected GameStateType _stateType;

    public GameStateType stateType { get { return _stateType; } }
    
    public event Action onEnter = null;

    public event Action onExit = null;

    public event Action onUpdate = null;

    public virtual void Init()
    {
        _stateController = GetComponent<GameStateController>();
    }

    public virtual void OnEnter()
    {        
        if (onEnter != null) onEnter();
    }

    public virtual void OnExit()
    {
        if (onExit != null) onExit();
    }

    public virtual void OnUpdate()
    {
        if (onUpdate != null) onUpdate();
    }
}

public enum GameStateType
{
    Init,
    Ready,
    Running,
    Paused,
    Succeed,
    Failure
}