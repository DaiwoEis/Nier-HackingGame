using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    private PawnHealth _player = null;

    [SerializeField]
    private GameObject _leftTrail = null;

    [SerializeField]
    private GameObject _rightTrail = null;

    private void Awake()
    {
        _player = GetComponent<PawnHealth>();
    }

    private void Update()
    {
        if (_player.currHealthAmount == 2)
        {
            _leftTrail.SetActive(false);
        }
        else if (_player.currHealthAmount == 1)
        {
            _rightTrail.SetActive(false);
        }
    }
}
