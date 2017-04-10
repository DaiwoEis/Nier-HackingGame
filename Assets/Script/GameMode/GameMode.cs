using CUI;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private float _gameInitStartTime = 3f;

    [SerializeField]
    private Pawn _player = null;

    [SerializeField]
    private Pawn _boss = null;

    [SerializeField]
    private BaseView _pausedView = null;

	private void Awake() { }

    private void Start()
    {
        GameStateController gameStateController = GameStateController.instance;
        CoroutineUtility.UStartCoroutine(_gameInitStartTime, () => gameStateController.ChangeState(GameStateType.Init));
        _player.onDeath += () => gameStateController.ChangeState(GameStateType.Failure);
        _boss.onDeath += () => gameStateController.ChangeState(GameStateType.Succeed);
        gameStateController.GetState(GameStateType.Running).onUpdate += () =>
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameStateController.instance.ChangeState(GameStateType.Paused);
        };
        _pausedView.onExit += () => gameStateController.ChangeState(GameStateType.Running);
    }

}
