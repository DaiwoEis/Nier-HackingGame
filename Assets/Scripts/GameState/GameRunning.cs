using UnityEngine;

public class GameRunning : GameState
{
    [SerializeField]
    private Pawn _boss = null;

    [SerializeField]
    private Pawn _player = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Running;

        _boss.onDeath += () =>
        {
            if (_stateController.currState == this)
            {
                _stateController.ChangeState(GameStateType.Succeed);
            }
        };

        _player.onDeath += () =>
        {
            if (_stateController.currState == this)
            {
                _stateController.ChangeState(GameStateType.Failure);
            }
        };
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