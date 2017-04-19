using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    [SerializeField]
    private GameState _currState = null;

    public GameState currState { get { return _currState; } }

    private Dictionary<GameStateType, GameState> _states = new Dictionary<GameStateType, GameState>();

    private bool _gameStarted = false;

    public event Action onGameStart = null;

    protected override void Init()
    {
        base.Init();

        foreach (var gameState in GetComponents<GameState>())
        {
            gameState.Init();
            _states.Add(gameState.stateType, gameState);
        }

        GetState(GameStateType.Running).onEnter += () =>
        {
            if (_gameStarted == false && onGameStart != null)
            {
                onGameStart();
                _gameStarted = true;
            }
        };

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
        if (_currState != null)
        {
            _currState.OnExit();            
        }

        _currState = _states[nextStateType];

        if (_currState != null)
        {
            _currState.OnEnter();
        }
    }
}