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
                currentIndex = 0; // �ݺ� �̵�
            }
        }
    }
    void Start()
    {
        // WayPoint ��� �̸��� �θ� ������Ʈ ã��
        GameObject waypointParent = GameObject.Find("WayPoint");

        skelOB = Resources.Load<GameObject>("Skills_Icon/Skel");

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

        Spawn();
    }
    public void Spawn()
    {
        if (skelOB != null)
        {
            spawned = Instantiate(skelOB, waypoints[0].position, Quaternion.identity);
            Debug.Log($"{skelOB} ��ų ������Ʈ�� �ʿ� ��ȯ��");
        }
        else
        {
            Debug.LogWarning("skelOB�� �������");
        }
    }
}

