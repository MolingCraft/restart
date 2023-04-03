using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public GameObject objectToPool;//池内的对象类型
    public int PoolFillAddNum;//每次向池内填充对象个数
    private List<GameObject> ObjectPoolList;


    private void Reset()
    {
        PoolFillAddNum=10;
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        ObjectPoolList = new List<GameObject>();
    }

    public void FillObjectPool(int num)
    {
        for (int i = 0; i < PoolFillAddNum; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            ObjectPoolList.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        if(ObjectPoolList.Count<=0)
        {
            FillObjectPool(PoolFillAddNum);
        }

        var obj=ObjectPoolList[0];
        ObjectPoolList.Remove(obj);

        return obj;
    }

    public void AddInPool(GameObject gameObject)
    {
        ObjectPoolList.Add(gameObject);
    }
}
