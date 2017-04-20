using UnityEngine;

public class SelfDestructionHitter : MonoBehaviour 
{
    private void Awake()
    {
        GetComponent<Hitter>().onHit += () =>
        {
            GetComponent<Actor>().Destroy();
            Destroy(gameObject);
        };
    }
}
