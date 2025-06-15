using UnityEngine;
using System.Collections;
public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% 확률로 발동

    public GameObject thunderEffectPrefab; // 시각효과(옵션)
    public float thunderMultiplier = 0;  // 공격력 계수


    public SkillGrade grade;

    public Button buttonManager;

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // 이벤트 구독
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // 해제
    }

    void Update()
    {
        grade = buttonManager.upgraded;

    }
    void Start()
    {
        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }


    }
    public void AttackThunder(Transform target)
    {
        Skillset();
        if (Random.value <= triggerChance)
        {
            float damage = Tower.Instance.damage * thunderMultiplier;

            // 데미지 적용
            MonsterHp monster = target.GetComponent<MonsterHp>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            // 번개 이펙트 생성 (선택사항)
            if (thunderEffectPrefab != null)
            {
                GameObject effect  = Instantiate(thunderEffectPrefab, target.position, Quaternion.identity);

                Destroy(effect, 1f);
            }

            Debug.Log($"Thunder  {damage} 데미지");
        }
    }
 
    public void Skillset()
    {
        if (grade == SkillGrade.SSS)
        {
            Debug.Log("sss 등급입니다.");
            thunderMultiplier = 2.7f;
        }
        if (grade == SkillGrade.SS)
        {
            Debug.Log("ss 등급입니다.");
            thunderMultiplier = 2.5f;
        }
        if (grade == SkillGrade.S)
        {
            Debug.Log("s 등급입니다.");
            thunderMultiplier = 2.3f;
        }
        if (grade == SkillGrade.A)
        {
            Debug.Log("a 등급입니다.");
            thunderMultiplier = 2.1f;
        }
        if (grade == SkillGrade.B)
        {
            Debug.Log("b 등급입니다.");
            thunderMultiplier = 1.9f;
        }
        if (grade == SkillGrade.C)
        {
            Debug.Log("c 등급입니다.");
            thunderMultiplier = 1.7f;
        }
        if (grade == SkillGrade.D)
        {
            Debug.Log("d 등급입니다.");
            thunderMultiplier = 1.5f;
        }
        if (grade == SkillGrade.E)
        {
            Debug.Log("e 등급입니다.");
            thunderMultiplier = 1.3f;
        }
        if (grade == SkillGrade.F)
        {
            Debug.Log("f 등급입니다.");
            thunderMultiplier = 1.1f;
        }
    }
}
