using CUI;
using UnityEngine;

public class GameReady : GameState
{
    [SerializeField]
    private CWindow _readyWindow = null;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Ready;

        _readyWindow.onClosingComplete += () => _stateController.ChangeState(GameStateType.Running);
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        WindowController.instance.AddCommond(new OpenCommond(_readyWindow));
    }
}