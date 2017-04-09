﻿using UnityEngine;

public class EnemyBulletBody : HitableBehaviour
{
    [SerializeField]
    private bool _canHittedWithWeakHitter = true;

    public override bool CanHit(Hitter hitter)
    {
        if (_canHittedWithWeakHitter)
        {
            return base.CanHit(hitter);
        }

        return base.CanHit(hitter) && hitter.hitType != HitType.Weak;
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        GetComponent<Actor>().Destroy();
    }
}