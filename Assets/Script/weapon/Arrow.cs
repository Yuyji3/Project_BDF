using UnityEngine;

public class arrow : MonoBehaviour
{
    private float _damage;
    public float speed = 10f;
    private Transform target;

    public void SetTarget(Transform t)
    {
        target = t;
        _damage = Tower.Instance.attackPower; // 여기서 가져옴
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterHp monsterhp = collision.GetComponent<MonsterHp>();
        if (monsterhp != null)
        {
            monsterhp.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
