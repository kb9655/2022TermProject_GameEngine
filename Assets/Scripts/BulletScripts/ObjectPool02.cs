using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool02 : MonoBehaviour
{
    public static ObjectPool02 Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    [SerializeField]
    private GameObject poolingObjectParent;

    Queue<Bullet02> poolingObjectQueue = new Queue<Bullet02>();

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

    private Bullet02 CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet02>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(poolingObjectParent.transform);
        
        return newObj;
    }

    public static Bullet02 GetObject()
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

    public static void ReturnObject(Bullet02 obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
