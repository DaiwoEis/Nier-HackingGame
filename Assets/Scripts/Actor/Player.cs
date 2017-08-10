public class Player : Actor 
{
    public override void OnSpawn()
    {
        base.OnSpawn();

        GameStateController.instance.onGameStart += BeginFunctions;
        GameStateController.instance.onGameSucced += EndFunctions;

        var health = GetComponent<PawnHealth>();
        health.onDeath += () =>
        {
            EndFunctions();
            this.StartCoroutine(health.dealthTime, () => { ActorManager.instance.DestroyObject(gameObject); });
        };
    }
}
