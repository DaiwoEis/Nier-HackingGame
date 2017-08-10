using System;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    protected GameStateController _stateController = null;

    protected GameStateType _stateType;

    public GameStateType stateType { get { return _stateType; } }
    
    public event Action<GameState> onEnter = null;

    public event Action<GameState> onExit = null;

    public event Action onUpdate = null;

    public virtual void Init(GameStateController controller)
    {
        _stateController = controller;
    }

    public virtual void OnEnter(GameState lastState)
    {        
        if (onEnter != null) onEnter(lastState);
    }

    public virtual void OnExit(GameState nextState)
    {
        if (onExit != null) onExit(nextState);
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