using CUI;
using UnityEngine;

public class GameFailure : GameState
{
    [SerializeField]
    private CWindow _failureWindow = null;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Failure;
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        WindowController.instance.AddCommond(new OpenCommond(_failureWindow));
    }
}