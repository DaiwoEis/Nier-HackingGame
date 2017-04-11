public class HealthHitableBody : HitableBehaviour
{
    private Pawn _health = null;

    private void Awake()
    {
        _health = GetComponent<Pawn>();
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        _health.TakeDamage(hitter, hitResult);
    }
}