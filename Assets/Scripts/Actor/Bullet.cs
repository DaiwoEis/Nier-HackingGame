using UnityEngine;

public class Bullet : Actor
{
    [SerializeField]
    private GameObject _destroyGO = null;

    protected override void Awake()
    {
        base.Awake();        

        if (_destroyGO == null)
            _destroyGO = gameObject;        
    }

    private void Start()
    {
        Spawn();
    }

    protected override void WhenSpawn()
    {
        base.WhenSpawn();

        ExecuteFunctions();

        if (GameStateController.instance.currStateType == GameStateType.Init)
        {
            PauseFunctions();
            GameStateController.instance.GetState(GameStateType.Running).onEnter += ResuneFunctions;
        }

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }

    protected override void WhenDestory()
    {
        base.WhenDestory();

        EndFunctions();
       
        if (GameStateController.instance != null)
        {
            GameStateController.instance.GetState(GameStateType.Paused).onEnter -= PauseFunctions;
            GameStateController.instance.GetState(GameStateType.Paused).onExit -= ResuneFunctions;
        }

        //Destroy(gameObject);
    }
}
