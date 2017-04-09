public class HealthHitableBody : HitableBehaviour
{
    private Pawn _health = null;

    private void Awake()
    {
        _health = GetComponent<Pawn>();
    }

    public override bool CanHit(Hitter hitter)
    {
        return base.CanHit(hitter) && !_health.isDead && !_health.isInvincible;
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        _health.TakeDamage(hitter, hitResult);
    }
}