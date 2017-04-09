﻿using System;
using UnityEngine;

[Serializable]
public class GameState
{
    protected GameStateController _stateController = null;

    [SerializeField]
    private GameStateType _stateType;

    public GameStateType stateType { get { return _stateType; } }
    
    public event Action onEnter = null;

    public event Action onExit = null;

    public event Action onUpdate = null;

    public GameState(GameStateController stateController, GameStateType stateType)
    {
        _stateController = stateController;
        _stateType = stateType;
    }

    public virtual void OnEnter()
    {        
        Debug.Log(stateType);
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
    Running,
    Paused,
    Succeed,
    Failure
}

public class GameInit : GameState
{
    public GameInit(GameStateController stateController) : base(stateController, GameStateType.Init)
    {

    }
}

public class GameRunning : GameState
{
    public GameRunning(GameStateController stateController) : base(stateController, GameStateType.Running)
    {

    }
}

public class GamePaused : GameState
{
    public GamePaused(GameStateController stateController) : base(stateController, GameStateType.Paused)
    {

    }
}

public class GameFailure : GameState
{
    public GameFailure(GameStateController stateController) : base(stateController, GameStateType.Failure)
    {

    }
}

public class GameSucceed : GameState
{
    public GameSucceed(GameStateController stateController) : base(stateController, GameStateType.Succeed)
    {

    }
}