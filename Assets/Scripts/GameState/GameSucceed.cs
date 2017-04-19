using CUI;
using UnityEngine;

public class GameSucceed : GameState
{
    [SerializeField]
    private BaseView _succeedView = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Succeed;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        ViewController.instance.AddCommond(new OpenCommond(_succeedView));
    }
}