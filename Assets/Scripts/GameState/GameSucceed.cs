using CUI;
using UnityEngine;

public class GameSucceed : GameState
{
    [SerializeField]
    private CWindow _succeedWindow = null;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Succeed;
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        WindowController.instance.AddCommond(new OpenCommond(_succeedWindow));
    }
}