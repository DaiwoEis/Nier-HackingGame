using UnityEngine;

public class Enemy : Pawn 
{
    protected override void Awake()
    {
        base.Awake();

        GameStateController.instance.onGameStart += Spawn;
        GameStateController.instance.GetState(GameStateType.Failure).onEnter += PauseFunctions;
    }

    public override void Spawn()
    {
        base.Spawn();

        ExecuteFunctions();

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

    public override void Death()
    {
        base.Death();

        GameStateController.instance.GetState(GameStateType.Paused).onEnter -= PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit -= ResuneFunctions;

        EndFunctions();

        foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.enabled = false;
        }
    }
}
