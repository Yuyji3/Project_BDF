using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;

    public float fireRate = 1f; // 공격 속도 (초당)
    public float damage = 1f;   // 공격력

    public float attackRange = 10f;

    private float timer;

    public static Tower Instance { get; private set; }

    public static event Action<Transform> OnAttack; // 공격 시 이벤트 발생

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            timer = 0f;

            GameObject target = FindClosestMonster();
            if (target != null)
            {
                ShootArrow(target.transform);

                OnAttack?.Invoke(target.transform);
            }
        }
    }

    void ShootArrow(Transform target)
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

        // Arrow 스크립트에 SetTarget 함수가 있다고 가정
        arrow.SendMessage("SetTarget", target, SendMessageOptions.DontRequireReceiver);
        arrow.SendMessage("SetDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    GameObject FindClosestMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject m in monsters)
        {
            float dist = Vector2.Distance(transform.position, m.transform.position);
            if (dist < minDistance && dist <= attackRange)
            {
                closest = m;
                minDistance = dist;
            }
        }

        return closest;
    }
}
