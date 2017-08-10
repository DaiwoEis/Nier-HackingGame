using UnityEngine;

public class PlayerBullet : Actor
{

    public override void OnSpawn()
    {
        base.OnSpawn();

        BeginFunctions();
        GetComponent<BulletHitter>().onHit += () => { ActorManager.instance.DestroyObject(gameObject); };
    }

    public override void OnRelease()
    {
        base.OnRelease();

        EndFunctions();
    }
}
