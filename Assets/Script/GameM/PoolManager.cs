using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolName;           // Ǯ �̸� (���п�)
    public GameObject prefab;         // Ǯ���� ������
    public int size = 10;        
    // �ʱ� ũ��
    [HideInInspector]
    public Queue<GameObject> objects; // Ǯ
}

public class PoolManager : MonoBehaviour
{
    public List<Pool> pools;      // ���� ���� Ǯ ���

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

    // Ǯ���� ������Ʈ ������ (�̸����� ã��)
    public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        Pool pool = pools.Find(x => x.poolName == poolName);
        if (pool == null)
        {
            Debug.LogWarning("�ش� Ǯ ����: " + poolName);
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

    // ������Ʈ�� Ǯ�� ����������
    public void ReturnToPool(string poolName, GameObject obj)
    {
        Pool pool = pools.Find(x => x.poolName == poolName);
        if (pool == null)
        {
            Debug.LogWarning("�ش� Ǯ ����: " + poolName);
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        pool.objects.Enqueue(obj);
    }
}
