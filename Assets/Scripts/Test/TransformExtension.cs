using UnityEngine;

public static class TransformExtension
{
    public static void Move(this Transform transform, Vector3 velocity)
    {
        transform.position += velocity*Time.deltaTime;
    }
}
