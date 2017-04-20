public class NoLifeActor : Actor
{
    private void Start()
    {
        Spawn();
    }

    protected override void WhenSpawn()
    {
        base.WhenSpawn();

        ExecuteFunctions();

        if (GameStateController.instance.currStateType != GameStateType.Running)
        {
            PauseFunctions();
            GameStateController.instance.GetState(GameStateType.Running).onEnter += ResuneFunctions;
        }

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

}
