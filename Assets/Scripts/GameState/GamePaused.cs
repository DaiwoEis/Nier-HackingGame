using CUI;
using UnityEngine;

public class GamePaused : GameState
{
    [SerializeField]
    private CWindow _pausedWindow = null;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Paused;

        _pausedWindow.onClosed += () => { _stateController.ChangeState(GameStateType.Running); };
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        Time.timeScale = 0f;
        WindowController.instance.AddCommond(new OpenCommond(_pausedWindow));
    }

    public override void OnExit(GameState nextState)
    {
        base.OnExit(nextState);

        Time.timeScale = 1f;
    }
}