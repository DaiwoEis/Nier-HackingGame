using UnityEngine;

public class TimeDestroyHitter : MonoBehaviour
{
    [SerializeField]
    private float _destroyTime = 0.5f;

	private void Awake() { }

    private void Start()
    {
        CoroutineUtility.UStartCoroutine(_destroyTime, () =>
        {
            GetComponent<Actor>().Destroy();
            Destroy(gameObject);
        });
    }
}
