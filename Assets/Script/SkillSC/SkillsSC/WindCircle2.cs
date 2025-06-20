using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WindCircle2 : MonoBehaviour
{

    public float damage;

    private WindCircle windCircle;

    private HashSet<MonsterHp> monstersInRange = new HashSet<MonsterHp>();

    private CircleCollider2D myCollider;

    public float minRadius = 0.5f;      // 최소 반지름
    public float maxRadius = 4f;        // 최대 반지름
    public float growTime = 0.1f;         // 커지는데 걸리는 시간
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
            // 커지기
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

            // 줄어들기
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
            Debug.Log("윈드에 부딪혀 데미지!" + damage);

        }
    }

}
