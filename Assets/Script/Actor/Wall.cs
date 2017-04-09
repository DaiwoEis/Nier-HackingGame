public class Wall : Actor
{
    protected override void Awake()
    {
        base.Awake();

        GameStateController.instance.onGameStart += Spawn;
    }

    public override void Spawn()
    {
        base.Spawn();

        ExecuteFunctions();

        //GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        //GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }
}
