using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_3 : MonoBehaviour
{
    public static ObjectPool_3 Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    [SerializeField]
    private GameObject poolingObjectParent;

    Queue<Bullet_3> poolingObjectQueue = new Queue<Bullet_3>();

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Bullet_3 CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet_3>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(poolingObjectParent.transform);
        
        return newObj;
    }

    public static Bullet_3 GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet_3 obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
