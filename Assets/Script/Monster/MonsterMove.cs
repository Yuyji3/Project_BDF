using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public List<Transform> waypoints;

    
    public float speed = 2f;

    private int currentIndex = 0;

    void Update()
    {
        if (waypoints.Count == 0) return;

        Transform target = waypoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        // 타겟 위치에 거의 도달했으면 다음으로
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            // 마지막 웨이포인트 도달 시 처음으로 되돌리기
            if (currentIndex >= waypoints.Count)
            {
                currentIndex = 0; // 순환 반복
            }
        }
    }
}
