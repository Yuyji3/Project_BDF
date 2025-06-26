using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolName;           // 풀 이름 (구분용)
    public GameObject prefab;         // 풀링할 프리팹
    public int size = 10;        
    // 초기 크기
    [HideInInspector]
    public Queue<GameObject> objects; // 풀
}

public class PoolManager : MonoBehaviour
{
    public List<Pool> pools;      // 여러 종류 풀 등록

    public static PoolManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        foreach (var pool in pools)
        {
            pool.objects = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                pool.objects.Enqueue(obj);
            }
        }
    }

    // 풀에서 오브젝트 꺼내기 (이름으로 찾기)
    public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        Pool pool = pools.Find(x => x.poolName == poolName);
        if (pool == null)
        {
            Debug.LogWarning("해당 풀 없음: " + poolName);
            return null;
        }

        GameObject obj;
        if (pool.objects.Count > 0)
        {
            obj = pool.objects.Dequeue();
        }
        else
        {
            obj = Instantiate(pool.prefab);
        }

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    // 오브젝트를 풀로 돌려보내기
    public void ReturnToPool(string poolName, GameObject obj)
    {
        Pool pool = pools.Find(x => x.poolName == poolName);
        if (pool == null)
        {
            Debug.LogWarning("해당 풀 없음: " + poolName);
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        pool.objects.Enqueue(obj);
    }
}
