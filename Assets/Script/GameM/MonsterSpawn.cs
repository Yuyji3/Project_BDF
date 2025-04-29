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
            Debug.LogError("Monster1 프리팹을 Resources/Prefeb/Monster/ 에서 찾을 수 없습니다!");
            return;
        }
        if (ptransform == null)
        {
            Debug.LogError("ptransform 프리팹을 Resources/Prefeb/Monster/ 에서 찾을 수 없습니다!");
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
            Debug.Log("몬스터 생성");
            yield return new WaitForSeconds(1f);
        }
        
    }


}
