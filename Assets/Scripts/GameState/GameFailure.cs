using CUI;
using UnityEngine;

public class GameFailure : GameState
{
    [SerializeField]
    private BaseView _failureView = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Failure;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        ViewController.instance.AddCommond(new OpenCommond(_failureView));
    }
}