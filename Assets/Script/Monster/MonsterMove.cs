using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    private float speed = 2f;
    private int currentIndex = 0;

    void Start()
    {
        // WayPoint ��� �̸��� �θ� ������Ʈ ã��
        GameObject waypointParent = GameObject.Find("WayPoint");

        if (waypointParent == null)
        {
            Debug.LogError("WayPoint ������Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        // WayPoint�� �ڽĵ��� ������� waypoints�� �߰�
        foreach (Transform child in waypointParent.transform)
        {
            waypoints.Add(child);
        }

        if (waypoints.Count == 0)
        {
            Debug.LogError("��������Ʈ�� �����ϴ�!");
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
                currentIndex = 0; // �ݺ� �̵�
            }
        }
    }
}
