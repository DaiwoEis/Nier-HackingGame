using CUI;
using UnityEngine;

public class GamePaused : GameState
{
    [SerializeField]
    private CWindow _pausedWindow = null;

#if UNITY_EDITOR
    [SerializeField]
    private string _pausedWindowName = "PausedWindow";

    public override void Setup()
    {
        base.Setup();

        _pausedWindow = GameObject.Find(_pausedWindowName).GetComponent<CWindow>();
    }
#endif

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Paused;
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        Time.timeScale = 0f;
        WindowController.instance.AddCommond(new OpenCommond(_pausedWindow));
        _pausedWindow.onClosed += Resume;
    }

    public override void OnExit(GameState nextState)
    {
        base.OnExit(nextState);

        Time.timeScale = 1f;
    }

    private void Resume()
    {
        _stateController.ChangeState(GameStateType.Running);
        _pausedWindow.onClosed -= Resume;
    }
}