using System.Threading;
using UnityEngine;

public class SkellAttack : MonoBehaviour
{
    [SerializeField]
    private SkelSC skelSC;

    public float damage;

    void Start()
    {
        
        skelSC = Tower.Instance.GetComponent<SkelSC>();

        
    }
    void Update()
    {
        if (skelSC == null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        skelSC.Skillset();

        damage = Tower.Instance.magicPower * skelSC.attack;

        if (other.CompareTag("Monster")) 
        {

            MonsterHp monster = other.GetComponent<MonsterHp>();

            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
            Debug.Log("차에 부딪혀 데미지!" + damage);
        }
    }
}
