using System.Collections;

public class GameLevelRoot : GameRoot 
{
    protected override void Awake()
    {
        base.Awake();

        WindowController.Create();
        UIManager.Create();
        GameStateController.Create();
        InputController.Create();
        ActorManager.Create();

        WindowController.instance.Run();
        WindowController.instance.transform.parent = transform;
        InputController.instance.transform.parent = transform;

        GameStateController.instance.Run();
    }

    protected override IEnumerator _Release()
    {
        yield return WindowController._Release();
        yield return UIManager._Release();
        yield return ActorManager._Release();
        yield return InputController._Release();
        yield return GameStateController._Release();
        yield return base._Release();
    }
}
