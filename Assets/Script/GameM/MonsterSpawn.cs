using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform ptransform;
    private GameObject monsterPrefab;

    void Start()
    {
        GameObject ground = GameObject.Find("Ground");
        Transform waypoint = ground.transform.Find("WayPoint");
        ptransform = waypoint.transform.Find("Point1");

        monsterPrefab = Resources.Load<GameObject>("Monster/Monster1");

        if (monsterPrefab == null)
        {
            Debug.LogError("Monster1 �������� Resources/Prefeb/Monster/ ���� ã�� �� �����ϴ�!");
            return;
        }
        if (ptransform == null)
        {
            Debug.LogError("ptransform �������� Resources/Prefeb/Monster/ ���� ã�� �� �����ϴ�!");
            return;
        }
        //Instantiate(monsterPrefab, ptransform.position, Quaternion.identity);

        StartCoroutine(Spawn());

    }


    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(monsterPrefab, ptransform.position, Quaternion.identity);
            Debug.Log("���� ����");
            yield return new WaitForSeconds(1f);
        }
        
    }


}
