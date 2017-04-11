using UnityEngine;

public class Bullet : Actor
{
    [SerializeField]
    private GameObject _destroyGO = null;

    protected override void Awake()
    {
        base.Awake();

        GameStateController.instance.GetState(GameStateType.Succeed).onEnter += () =>
        {
            if (_worked) Destroy();
        };
        GameStateController.instance.GetState(GameStateType.Failure).onEnter += () =>
        {
            if (_worked) Destroy();
        };

        if (_destroyGO == null)
            _destroyGO = gameObject;
    }

    private void Start()
    {
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();

        ExecuteFunctions();

        if (GameStateController.instance.currStateType == GameStateType.Paused)
            PauseFunctions();

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

    public override void Destroy()
    {
        base.Destroy();

        EndFunctions();

        GameStateController gameStateController = GameStateController.instance;
        if (gameStateController != null)
        {
            GameStateController.instance.GetState(GameStateType.Paused).onEnter -= PauseFunctions;
            GameStateController.instance.GetState(GameStateType.Paused).onExit -= ResuneFunctions;
        }

        Destroy(_destroyGO);
    }
}
