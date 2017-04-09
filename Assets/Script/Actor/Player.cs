using UnityEngine;

public class Player : Pawn
{
    [SerializeField]
    private AudioClip _hurtClip = null;

    private AudioSource _audioSource = null;

    protected override void Awake()
    {
        base.Awake();

        GameStateController.instance.onGameStart += Spawn;

        //onHurtExit += ResuneFunctions;

        _audioSource = GetComponent<AudioSource>();
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

        _audioSource.clip = _hurtClip;
        _audioSource.Play();

        //PauseFunctions();
    }
}
