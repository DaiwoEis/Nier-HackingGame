public class Enemy : Pawn 
{
    protected override void Awake()
    {
        base.Awake();

        Spawn();        
    }

    //protected override void WhenSpawn()
    //{
    //    base.WhenSpawn();

    //    GameStateController.instance.GetState(GameStateType.Failure).onEnter += PauseFunctions;
    //}

    //protected override void WhenDeath()
    //{
    //    base.WhenDeath();

    //    if (GameStateController.instance == null) return;

    //    GameStateController.instance.GetState(GameStateType.Failure).onEnter -= PauseFunctions;
    //}
}
