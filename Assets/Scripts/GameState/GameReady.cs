using CUI;
using UnityEngine;

public class GameReady : GameState
{
    [SerializeField]
    private CWindow _readyWindow = null;

#if UNITY_EDITOR
    [SerializeField]
    private string _readyWindowName = "ReadyWindow";

    public override void Setup()
    {
        base.Setup();

        _readyWindow = GameObject.Find(_readyWindowName).GetComponent<CWindow>();
    }
#endif

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Ready;
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        WindowController.instance.AddCommond(new OpenCommond(_readyWindow));
        _readyWindow.onClosed += Run;
    }

    private void Run()
    {
        _stateController.ChangeState(GameStateType.Running);
        _readyWindow.onClosed -= Run;
    }
}