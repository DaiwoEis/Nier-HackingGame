public class Bullet : Actor
{
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
    }

    private void Start()
    {
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();

        ExecuteFunctions();

        //GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        //GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

    public override void Destroy()
    {
        base.Destroy();

        EndFunctions();

        //GameStateController gameStateController = GameStateController.instance;
        //if (gameStateController != null)
        //{
        //    GameStateController.instance.GetState(GameStateType.Paused).onEnter -= PauseFunctions;
        //    GameStateController.instance.GetState(GameStateType.Paused).onExit -= ResuneFunctions;
        //}

        Destroy(gameObject);
    }
}
