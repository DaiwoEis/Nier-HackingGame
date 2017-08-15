public class Wall : Actor
{
    public override void OnSpawn()
    {
        base.OnSpawn();

        GameStateController.instance.onGameStart += BeginFunctions;
    }

    public override void OnRelease()
    {
        base.OnRelease();

        GameStateController.instance.onGameStart -= BeginFunctions;
        EndFunctions();
    }
}
