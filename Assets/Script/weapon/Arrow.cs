using UnityEngine;

public class arrow : MonoBehaviour
{

    private float _damage = 1f;

    MonsterHp monsterhp;
    public float speed = 10f;

    private Transform target;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // 대상이 사라지면 화살도 파괴
            return;
        }

        // 방향 계산
        Vector3 dir = (target.position - transform.position).normalized;

        // 위치 이동
        transform.position += dir * speed * Time.deltaTime;

        // 회전 방향 맞추기 (z축 기준)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        monsterhp = collision.GetComponent<MonsterHp>();
        if (monsterhp == null) Debug.Log("몬스터 체력 가져올수 없음");

        monsterhp.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
