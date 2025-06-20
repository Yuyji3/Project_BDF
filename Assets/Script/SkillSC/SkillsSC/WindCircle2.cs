using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WindCircle2 : MonoBehaviour
{

    public float damage;

    private WindCircle windCircle;

    private HashSet<MonsterHp> monstersInRange = new HashSet<MonsterHp>();

    private CircleCollider2D myCollider;

    public float minRadius = 0.5f;      // �ּ� ������
    public float maxRadius = 4f;        // �ִ� ������
    public float growTime = 0.1f;         // Ŀ���µ� �ɸ��� �ð�
    public float shrinkTime = 0.1f;

    void Start()
    {
        windCircle = Tower.Instance.GetComponent<WindCircle>();

        myCollider = GetComponent<CircleCollider2D>();
        StartCoroutine(GrowShrinkRoutine());

        Destroy(windCircle);
    }

    void Update()
    {

        if (windCircle == null)
        {
            Destroy(windCircle);
        }
        myCollider.radius = minRadius;
    }
    IEnumerator GrowShrinkRoutine()
    {
        while (true)
        {
            // Ŀ����
            float timer = 0f;
            while (timer < growTime)
            {
                myCollider.radius = Mathf.Lerp(minRadius, maxRadius, timer / growTime);
                timer += Time.deltaTime;
                windCircle.Spawn();
                yield return null;
            }
            myCollider.radius = maxRadius;

            windCircle.Spawn();

            // �پ���
            timer = 0f;
            while (timer < shrinkTime)
            {
                myCollider.radius = Mathf.Lerp(maxRadius, minRadius, timer / shrinkTime);
                timer += Time.deltaTime;
                yield return null;
            }
            myCollider.radius = minRadius;

            yield return new WaitForSeconds(2f);
            Destroy(windCircle);
            yield return new WaitForSeconds(3f);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Monster"))
        {
            damage = Tower.Instance.magicPower * windCircle.windAttack;

            MonsterHp monster = other.GetComponent<MonsterHp>();

            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
            Debug.Log("���忡 �ε��� ������!" + damage);

        }
    }

}
