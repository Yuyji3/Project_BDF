using UnityEngine;

public enum WeaponType { Arrow, Stone, Ice, Fire }

public class Attack : MonoBehaviour
{
    public WeaponType selectedWeapon = WeaponType.Arrow;

    public GameObject arrowPrefab;
    public GameObject stonePrefab;
    public GameObject icePrefab;
    public GameObject firePrefab;

    public Transform firePoint;
    public float fireRate = 1f;
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
                ShootWeapon(target.transform);
            }
        }
        //Debug.Log(selectedWeapon);
    }

    void ShootWeapon(Transform target)
    {
        GameObject prefab = GetSelectedWeaponPrefab();
        GameObject weapon = Instantiate(prefab, firePoint.position, Quaternion.identity);

        // 각 무기 스크립트에 SetTarget()이 있을 경우
        weapon.SendMessage("SetTarget", target, SendMessageOptions.DontRequireReceiver);
    }

    GameObject GetSelectedWeaponPrefab()
    {
        switch (selectedWeapon)
        {
            case WeaponType.Stone:
                return stonePrefab;
            case WeaponType.Ice:
                return icePrefab;
            case WeaponType.Fire:
                return firePrefab;
            default:
                return arrowPrefab;
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

    public void SetWeaponType(WeaponType type)
    {
        selectedWeapon = type;
    }
}
