public class EnemyBulletBody : NoHealthBody
{
    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        base.Hit(hitter, hitResult);

        ActorManager.instance.DestroyObject(gameObject);
    }
}
