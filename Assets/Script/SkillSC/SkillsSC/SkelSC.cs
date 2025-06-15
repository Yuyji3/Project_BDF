using System.Collections.Generic;
using UnityEngine;

public class SkelSC : MonoBehaviour
{

    private List<Transform> waypoints = new List<Transform>();

    private float speed = 20f;
    private int currentIndex = 0;

    public GameObject spawned;

    private GameObject skelOB;

    public SkillGrade grade;

    void Update()
    {
        if (waypoints.Count == 0) return;

        Transform target = waypoints[currentIndex];
        Vector3 direction = (target.position - spawned.transform.position).normalized;

        spawned.transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(spawned.transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            if (currentIndex >= waypoints.Count)
            {
                currentIndex = 0; // 반복 이동
            }
        }
    }
    void Start()
    {
        // WayPoint 라는 이름의 부모 오브젝트 찾기
        GameObject waypointParent = GameObject.Find("WayPoint");

        skelOB = Resources.Load<GameObject>("Skills_Icon/Skel");

        if (waypointParent == null)
        {
            Debug.LogError("WayPoint 오브젝트를 찾을 수 없습니다!");
            return;
        }

        // WayPoint의 자식들을 순서대로 waypoints에 추가
        foreach (Transform child in waypointParent.transform)
        {
            waypoints.Add(child);
        }

        if (waypoints.Count == 0)
        {
            Debug.LogError("웨이포인트가 없습니다!");
        }

        Spawn();
    }
    public void Spawn()
    {
        if (skelOB != null)
        {
            spawned = Instantiate(skelOB, waypoints[0].position, Quaternion.identity);
            Debug.Log($"{skelOB} 스킬 오브젝트가 맵에 소환됨");
        }
        else
        {
            Debug.LogWarning("skelOB이 비어있음");
        }
    }
}

