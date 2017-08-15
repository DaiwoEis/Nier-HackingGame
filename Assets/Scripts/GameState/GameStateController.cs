using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    [SerializeField]
    private GameState _currState = null;

    public GameState currState { get { return _currState; } }

    private Dictionary<GameStateType, GameState> _states = new Dictionary<GameStateType, GameState>();

    public event Action onGameStart = null;

    public event Action onGamePaused = null;

    public event Action onGameResumed = null;

    public event Action onGameSucced = null;

    public event Action onGameFailure = null;

    protected override void OnCreate()
    {
        base.OnCreate();

        foreach (var gameState in GetComponentsInChildren<GameState>())
        {
            gameState.Init(this);
            _states.Add(gameState.stateType, gameState);
        }

        GetState(GameStateType.Running).onEnter += (lastState) =>
        {
            if (lastState.stateType == GameStateType.Ready && onGameStart != null)
                onGameStart();
        };

        GetState(GameStateType.Paused).onEnter += (lastState) =>
        {
            if (onGamePaused != null) onGamePaused();
        };
        GetState(GameStateType.Paused).onExit += (nextState) =>
        {
            if (onGameResumed != null) onGameResumed();
        };

        GetState(GameStateType.Succeed).onEnter += (lastState) =>
        {
            if (onGameSucced != null) onGameSucced();
        };

        GetState(GameStateType.Failure).onEnter += (lastState) =>
        {
            if (onGameFailure != null) onGameFailure();
        };
    }

    protected override IEnumerator _OnRelease()
    {
        yield return base._OnRelease();
        if (_currState != null)
            _currState.OnExit(null);
    }

    public void Run()
    {
        ChangeState(GameStateType.Init);
    }

    private void Update()
    {
        if (_currState != null)
        {
            _currState.OnUpdate();
        }
    }

    public GameStateType currStateType { get { return _currState.stateType; } }

    public GameState GetState(GameStateType stateType)
    {
        return _states[stateType];
    }

    public void ChangeState(GameStateType nextStateType)
    {
        var lastState = _currState;
        var nextState = _states[nextStateType];

        if (lastState != null)
        {
            lastState.OnExit(nextState);            
        }

        _currState = nextState;

        if (nextState != null)
        {
            nextState.OnEnter(lastState);
        }
    }
}