using CUI;
using UnityEngine;

public class GameReady : GameState
{
    [SerializeField]
    private BaseView _readyView = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Ready;

        _readyView.onExit += () => _stateController.ChangeState(GameStateType.Running);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        ViewController.instance.AddCommond(new OpenCommond(_readyView));
    }
}