using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletHitter : Hitter
{
    protected override void WhenTriggerEnter(Collider other)
    {
        HitCheck(other);
    }
}