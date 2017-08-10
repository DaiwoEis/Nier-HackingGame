using UnityEngine;

public class GameInit : GameState
{
    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Init;
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        SceneChangeEffect effect = Camera.main.GetComponent<SceneChangeEffect>();
        if (effect != null)
        {
            effect.RunReverse(() => _stateController.ChangeState(GameStateType.Ready));
        }
        else
        {
            _stateController.ChangeState(GameStateType.Ready);
        }
    }
}