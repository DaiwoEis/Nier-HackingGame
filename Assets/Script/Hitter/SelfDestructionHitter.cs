public class SelfDestructionHitter : Hitter 
{
    private void Awake()
    {
        OnHit += GetComponent<Actor>().Destroy;
    }
}
