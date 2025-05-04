using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Attack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float arrowSpeed = 10f;
    public float attackRange = 10f;

    private float timer;

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
            }
        }
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

    void ShootArrow(Transform target)
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        arrow.GetComponent<arrow>().SetTarget(target);
    }
}
