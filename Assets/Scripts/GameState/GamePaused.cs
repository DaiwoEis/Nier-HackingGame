using CUI;
using UnityEngine;

public class GamePaused : GameState
{
    [SerializeField]
    private BaseView _pausedView = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Paused;

        _pausedView.onExit += () =>
        {
            if (_stateController.currState == this)
            {
                _stateController.ChangeState(GameStateType.Running);
            }
        };
    }

    public override void OnEnter()
    {
        base.OnEnter();

        ViewController.instance.AddCommond(new OpenCommond(_pausedView));
        Time.timeScale = 0f;
    }

    public override void OnExit()
    {
        base.OnExit();

        Time.timeScale = 1f;
    }
}