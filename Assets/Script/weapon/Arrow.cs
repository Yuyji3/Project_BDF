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
            Destroy(gameObject); // ����� ������� ȭ�쵵 �ı�
            return;
        }

        // ���� ���
        Vector3 dir = (target.position - transform.position).normalized;

        // ��ġ �̵�
        transform.position += dir * speed * Time.deltaTime;

        // ȸ�� ���� ���߱� (z�� ����)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        monsterhp = collision.GetComponent<MonsterHp>();
        if (monsterhp == null) Debug.Log("���� ü�� �����ü� ����");

        monsterhp.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
