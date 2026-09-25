using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
  private Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();
  public static PoolManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    public void RegisterPrefab(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            Pool newPool = new GameObject(prefab.name + "Pool").AddComponent<Pool>();
            newPool.Prefab = prefab;
            newPool.transform.SetParent(transform);
            pools.Add(prefab, newPool);
        }
    }
     public GameObject GetObject(GameObject prefab, Vector3 position)
    {
        if (pools.TryGetValue(prefab, out Pool pool))
        {
            pool.InstantiateObject(position);
            return pool.CurrenObject;
        }
        else
        {
            RegisterPrefab(prefab);
            return GetObject(prefab, position);
        }
    }
}
