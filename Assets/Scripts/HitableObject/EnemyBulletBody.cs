using CodingJar;
using UnityEngine;

public class EnemyBulletBody : NoHealthBody
{
    [EnumFlagsField, SerializeField]
    private HitType _canHitType = HitType.Weak;

    public override bool CanHit(Hitter hitter)
    {
        return base.CanHit(hitter) && LayerUtility.InLayerMask((int) hitter.hitType, (int) _canHitType);
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        base.Hit(hitter, hitResult);

        GetComponent<Actor>().Destroy();
    }
}
