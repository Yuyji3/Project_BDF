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

        // Ÿ�� ��ġ�� ���� ���������� ��������
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            // ������ ��������Ʈ ���� �� ó������ �ǵ�����
            if (currentIndex >= waypoints.Count)
            {
                currentIndex = 0; // ��ȯ �ݺ�
            }
        }
    }
}
