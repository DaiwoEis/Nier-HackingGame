﻿using UnityEngine;

namespace EZObjectPools
{
    [AddComponentMenu("EZ Object Pools/Pooled Object")]
    public class PooledObject : MonoBehaviour
    {
        protected EZObjectPool _ownerPool;

        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }

        public void SetUp(EZObjectPool pool)
        {
            _ownerPool = pool;
        }

        public void ReturnToPool()
        {
            OnReturnToPool();

            if (transform != null)
            {
                transform.position = Vector3.zero;
            }

            if (_ownerPool != null)
            {
                _ownerPool.AddToAvailableObjects(gameObject);
                transform.SetParent(_ownerPool.transform);
            }
            else
            {
                Debug.LogWarning("PooledObject " + gameObject.name +
                                 " does not have a parent pool. If this occurred during a scene transition, ignore this. Otherwise reoprt to developer.");
            }

            gameObject.SetActive(false);
        }

        public virtual void OnReturnToPool()
        {
            
        }

        public virtual void OnRetrieveFromPool()
        {
            
        }

        public virtual void OnInstatiateFromPool()
        {
            
        }
    }
}