public class Boss : Actor 
{
    public override void OnSpawn()
    {
        base.OnSpawn();

        GameStateController.instance.onGameStart += BeginFunctions;
        GameStateController.instance.onGameFailure += EndFunctions;

        var health = GetComponent<PawnHealth>();
        health.onDeath += () =>
        {
            EndFunctions();
            this.StartCoroutine(health.dealthTime, () => { ActorManager.instance.DestroyObject(gameObject); });
        };
    }

    public override void OnRelease()
    {
        base.OnRelease();

        GameStateController.instance.onGameStart -= BeginFunctions;
        GameStateController.instance.onGameFailure -= EndFunctions;
    }
}
