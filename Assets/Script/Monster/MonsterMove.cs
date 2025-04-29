using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    private float speed = 2f;
    private int currentIndex = 0;

    void Start()
    {
        // WayPoint 라는 이름의 부모 오브젝트 찾기
        GameObject waypointParent = GameObject.Find("WayPoint");

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
    }

    void Update()
    {
        if (waypoints.Count == 0) return;

        Transform target = waypoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            if (currentIndex >= waypoints.Count)
            {
                currentIndex = 0; // 반복 이동
            }
        }
    }
}
