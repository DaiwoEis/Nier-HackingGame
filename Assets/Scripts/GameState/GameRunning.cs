using UnityEngine;

public class GameRunning : GameState
{
    private Actor _boss = null;

    private Actor _player = null;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Running;
        _player = GameObject.Find(TagConfig.Player).GetComponent<Actor>();
        _boss = GameObject.Find(TagConfig.Boss).GetComponent<Actor>();
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        _boss.onDestroy += Succeed;
        _player.onDestroy += Failure;
    }

    public override void OnExit(GameState nextState)
    {
        base.OnExit(nextState);

        _boss.onDestroy -= Succeed;
        _player.onDestroy -= Failure;
    }

    private void Succeed()
    {
        _stateController.ChangeState(GameStateType.Succeed);
    }

    private void Failure()
    {
        _stateController.ChangeState(GameStateType.Failure);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

#if !MOBILE_PLATFORM
        if (Input.GetButtonDown("Cancel"))
        {
            _stateController.ChangeState(GameStateType.Paused);
        }
#endif
    }
}