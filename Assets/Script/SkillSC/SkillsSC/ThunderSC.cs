using UnityEngine;
using System.Collections;
public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% 확률로 발동

    //private GameObject EffectPrefab; // 시각효과(옵션)
    public float thunderMultiplier = 0;  // 공격력 계수

    public SkillGrade grade;

    public Button buttonManager;

    private int currentint3;

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // 이벤트 구독
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // 해제
    }


    void Start()
    {
        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        currentint3 = buttonManager.currentInt3;

    }
    public void AttackThunder(Transform target)
    {
        Skillset();
        if (Random.value <= triggerChance)
        {
            
            float damage = Tower.Instance.attackPower * thunderMultiplier;

            // 데미지 적용
            MonsterHp monster = target.GetComponent<MonsterHp>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            // 번개 이펙트 생성 (선택사항)


            GameObject effect = PoolManager.Instance.SpawnFromPool("Thunder", target.position, Quaternion.identity);

            StartCoroutine(ReturnEffectToPool(effect));
            

            Debug.Log($"Thunder  {damage} 데미지");
        }
    }
    private IEnumerator ReturnEffectToPool(GameObject effect)
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.ReturnToPool("Thunder", effect);
    }

    public void Skillset()
    {

        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {
            Debug.Log("썬더 sss 등급입니다.");
            thunderMultiplier = 2.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {
            Debug.Log("썬더ss 등급입니다.");
            thunderMultiplier = 2.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
            Debug.Log("썬더s 등급입니다.");
            thunderMultiplier = 2.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {
            Debug.Log("썬더a 등급입니다.");
            thunderMultiplier = 2.1f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {
            Debug.Log("썬더b 등급입니다.");
            thunderMultiplier = 1.9f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
            Debug.Log("썬더c 등급입니다.");
            thunderMultiplier = 1.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
            Debug.Log("썬더d 등급입니다.");
            thunderMultiplier = 1.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
            Debug.Log("썬더e 등급입니다.");
            thunderMultiplier = 1.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {
            Debug.Log("썬더f 등급입니다.");
            thunderMultiplier = 1.1f;
        }
    }
}
