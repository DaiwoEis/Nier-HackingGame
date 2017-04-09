﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StraightMove : FunctionBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    
    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
                                 RigidbodyConstraints.FreezeRotationZ;
        _rigidbody.useGravity = false;
    }

    protected override void OnExecute()
    {
        base.OnExecute();

        _rigidbody.velocity = transform.forward*_moveSpeed;
    }
}
