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
                currentIndex = 0; // 반복 이동
            }
        }
    }
    void Start()
    {
        // WayPoint 라는 이름의 부모 오브젝트 찾기
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
            Destroy(spawned);
        }
    }

    public void Skillset()
    {
        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {
            Debug.Log("스켈 sss 등급입니다.");
            attack = 2.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {
            Debug.Log("스켈ss 등급입니다.");
            attack = 2.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
            Debug.Log("스켈s 등급입니다.");
            attack = 2.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {
            Debug.Log("스켈a 등급입니다.");
            attack = 2.1f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {
            Debug.Log("스켈b 등급입니다.");
            attack = 1.9f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
            Debug.Log("스켈c 등급입니다.");
            attack = 1.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
            Debug.Log("스켈d 등급입니다.");
            attack = 1.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
            Debug.Log("스켈e 등급입니다.");
            attack = 1.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {
            Debug.Log("스켈f 등급입니다.");
            attack = 1.1f;
        }
    }
}

