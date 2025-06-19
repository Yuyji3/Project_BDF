using System.Threading;
using UnityEngine;

public class SkellAttack : MonoBehaviour
{
    private SkelSC skelSC;

    [SerializeField]
    private GameObject tower;

    void Start()
    {
        tower = GameObject.Find("Tower");
        skelSC = tower.GetComponent<SkelSC>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")) 
        {

            MonsterHp monster = other.GetComponent<MonsterHp>();

            if (monster != null)
            {
                monster.TakeDamage(skelSC.attack);
            }
            Debug.Log("차에 부딪혀 데미지!");
        }
    }
}
