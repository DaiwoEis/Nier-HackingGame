public class GameLevelRoot : GameRoot 
{
    protected override void Awake()
    {
        base.Awake();

        GameStateController.Create();
        InputController.Create();
        ActorManager.Create();

        GameStateController.instance.transform.parent = transform;
        InputController.instance.transform.parent = transform;
        ActorManager.instance.transform.parent = transform;
    }

    protected override void ClearGameController()
    {
        ActorManager.Release();
        InputController.Release();
        GameStateController.Release();

        base.ClearGameController();
    }
}
