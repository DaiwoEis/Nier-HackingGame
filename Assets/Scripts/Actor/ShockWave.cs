using UnityEngine;

public class ShockWave : Actor
{
    [SerializeField]
    private float _destroyTime = 1f;

    public override void OnSpawn()
    {
        base.OnSpawn();

        BeginFunctions();
        this.StartCoroutine(_destroyTime, () => ActorManager.instance.DestroyObject(gameObject));
    }

    public override void OnRelease()
    {
        base.OnRelease();

        EndFunctions();
    }
}
