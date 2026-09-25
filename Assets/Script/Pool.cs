using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
private Stack<GameObject> poolStack = new Stack<GameObject> ();
    private readonly HashSet<GameObject> activeObjects = new HashSet<GameObject> ();
    public IReadOnlyCollection<GameObject> ActiveObjects => activeObjects;
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab { set  { prefab = value; } }
    private GameObject currentObject;
    public GameObject CurrenObject => currentObject;
    public void InstantiateObject(Vector3 positino)
    {
        if (poolStack.Count > 0)
        {
            currentObject = poolStack.Pop ();
            currentObject.transform.position = positino;
            currentObject.SetActive (true);
        }
        else
        {
            currentObject = Instantiate(prefab);
            currentObject.AddComponent<PoolObject>().Pool = this;
        }
        activeObjects.Add(currentObject);
    }
    public void InstantiateObject(Transform parent)
    {
        InstantiateObject(parent.position);
    }
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
        poolStack.Push(obj);
    }
}
