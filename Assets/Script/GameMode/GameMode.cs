using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private Pawn _player = null;

    [SerializeField]
    private Pawn _boss = null;

	private void Awake() { }

    private void Start()
    {
        CoroutineUtility.UStartCoroutine(1f, () => GameStateController.instance.ChangeState(GameStateType.Running));
        _player.onDeath += () => GameStateController.instance.ChangeState(GameStateType.Failure);
        _boss.onDeath += () => GameStateController.instance.ChangeState(GameStateType.Succeed);
        GameStateController.instance.GetState(GameStateType.Running).onUpdate += () =>
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameStateController.instance.ChangeState(GameStateType.Paused);
        };
        GameStateController.instance.GetState(GameStateType.Paused).onUpdate += () =>
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameStateController.instance.ChangeState(GameStateType.Running);
        };
    }

}
