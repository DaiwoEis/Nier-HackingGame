using System.Collections.Generic;
using EZObjectPools;
using UnityEngine;

public class ActorManager : MonoSingleton<ActorManager>
{
    [SerializeField]
    private GameObject[] templates = null;

    private Dictionary<GameObject, EZObjectPool> _poolDic = null;

    protected override void OnCreate()
    {
        base.OnCreate();

        foreach (var actor in FindObjectsOfType<Actor>())
        {
            if (!actor.isTemplate) actor.OnSpawn();
        }
        
        _poolDic = new Dictionary<GameObject, EZObjectPool>();
        foreach (var prefab in templates)
            _poolDic[prefab] = EZObjectPool.CreateObjectPool(prefab, prefab.name, 20);
    }

    protected override void OnRelease()
    {
        base.OnRelease();

        foreach (var actor in FindObjectsOfType<Actor>())
        {
            if (!actor.isTemplate) actor.OnRelease();
        }
    }

    public GameObject CreateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject;
        if (_poolDic.ContainsKey(prefab))
        {
            _poolDic[prefab].TryGetNextObject(position, rotation, out newObject);
        }
        else
        {
            newObject = Instantiate(prefab, position, rotation);
        }

        var actor = newObject.GetComponent<Actor>();
        if (actor != null) actor.OnSpawn();
        
        return newObject;
    }

    public void DestroyObject(GameObject go)
    {
        var actor = go.GetComponent<Actor>();
        if (actor != null) actor.OnRelease();

        var pooledObject = go.GetComponent<PooledObject>();
        if (pooledObject == null)
            Destroy(go);
        else
            pooledObject.ReturnToPool();
    }
}
