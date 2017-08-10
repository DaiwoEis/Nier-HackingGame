using UnityEngine;

public class ShockWaveHitter : Hitter
{
    protected override void WhenTriggerStay(Collider other)
    {
        base.WhenTriggerStay(other);

        HitCheck(other);
    }
}
