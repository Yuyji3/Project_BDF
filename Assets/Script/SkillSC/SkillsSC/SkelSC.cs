using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkelSC : MonoBehaviour
{

    private List<Transform> waypoints = new List<Transform>();

    private float speed = 8f;
    private int currentIndex = 0;

    public float attack = 0.5f;

    private GameObject spawned;

    private GameObject skelOB;

    public SkillGrade grade;

    private Button buttonManager;

    private int currentint3;

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

        

        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        currentint3 = buttonManager.currentInt3;

        Skillset();

        skelOB = Resources.Load<GameObject>("Skills_Prefab/Skel");

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
            Destroy(spawned);
        }
    }

    public void Skillset()
    {
        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {
            Debug.Log("���� sss ����Դϴ�.");
            attack = 2.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {
            Debug.Log("����ss ����Դϴ�.");
            attack = 2.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
            Debug.Log("����s ����Դϴ�.");
            attack = 2.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {
            Debug.Log("����a ����Դϴ�.");
            attack = 2.1f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {
            Debug.Log("����b ����Դϴ�.");
            attack = 1.9f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
            Debug.Log("����c ����Դϴ�.");
            attack = 1.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
            Debug.Log("����d ����Դϴ�.");
            attack = 1.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
            Debug.Log("����e ����Դϴ�.");
            attack = 1.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {
            Debug.Log("����f ����Դϴ�.");
            attack = 1.1f;
        }
    }
}

