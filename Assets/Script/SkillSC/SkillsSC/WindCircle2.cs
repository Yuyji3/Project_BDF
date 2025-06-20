using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WindCircle2 : MonoBehaviour
{

    public float damage;

    private WindCircle windCircle;

    private HashSet<MonsterHp> monstersInRange = new HashSet<MonsterHp>();

    private CircleCollider2D myCollider;


    private ParticleSystem particleSystem;
    void Start()
    {
        windCircle = Tower.Instance.GetComponent<WindCircle>();
        particleSystem = GetComponent<ParticleSystem>(); 

        myCollider = GetComponent<CircleCollider2D>();
        StartCoroutine(GrowShrinkRoutine());

    }

    void Update()
    {

        if (windCircle == null)
        {
            Destroy(windCircle);
        }

    }
    IEnumerator GrowShrinkRoutine()
    {
        while (true) { 

            myCollider.enabled = true;
            particleSystem.Play();
            yield return new WaitForSeconds(1f);
            myCollider.enabled = false;
            particleSystem.Stop();
            yield return new WaitForSeconds(2f);


        }
        //while (true)
        //{
        //    // 커지기
        //    float timer = 0f;
        //    while (timer < growTime)
        //    {
        //        myCollider.radius = Mathf.Lerp(minRadius, maxRadius, timer / growTime);
        //        timer += Time.deltaTime;

        //        yield return null;
        //    }
        //    myCollider.radius = maxRadius;


        //    Debug.Log("커졌다");
        //    // 줄어들기
        //    timer = 0f;
        //    while (timer < shrinkTime)
        //    {
        //        myCollider.radius = Mathf.Lerp(maxRadius, minRadius, timer / shrinkTime);
        //        timer += Time.deltaTime;
        //        yield return null;
        //    }
        //    myCollider.radius = minRadius;

        //    yield return new WaitForSeconds(2f);
  
        //    Debug.Log("작아졌다");
        //    yield return new WaitForSeconds(3f);

        //}
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
