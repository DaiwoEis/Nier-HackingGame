using UnityEngine;

public class PlayerTrailController : MonoBehaviour
{
    private Pawn _player = null;

    [SerializeField]
    private GameObject _leftTrail = null;

    [SerializeField]
    private GameObject _rightTrail = null;

    private void Awake()
    {
        _player = GetComponent<Pawn>();
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
