public class Boss : Pawn 
{
    protected override void Awake()
    {
        base.Awake();

        GameStateController.instance.onGameStart += Spawn;

        //onHurtExit += ResuneFunctions;
    }

    public override void Spawn()
    {
        base.Spawn();

        ExecuteFunctions();

        //GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        //GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

    public override void Death()
    {
        base.Death();

        EndFunctions();
    }

    protected override void Hurt()
    {
        base.Hurt();

        //PauseFunctions();
    }
}
