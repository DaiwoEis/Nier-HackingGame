using UnityEngine;

public class TimeDestroyHitter : Hitter
{
    [SerializeField]
    private float _destroyTime = 0.5f;

	private void Awake() { }

    private void Start()
    {
        CoroutineUtility.UStartCoroutine(_destroyTime, () => { GetComponent<Actor>().Destroy(); });
    }
}
