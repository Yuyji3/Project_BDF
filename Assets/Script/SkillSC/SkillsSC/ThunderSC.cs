using UnityEngine;
using System.Collections;
public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% Ȯ���� �ߵ�

    public GameObject thunderEffectPrefab; // �ð�ȿ��(�ɼ�)
    public float thunderMultiplier = 0;  // ���ݷ� ���


    public SkillGrade grade;

    public Button buttonManager;

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // �̺�Ʈ ����
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // ����
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

            // ������ ����
            MonsterHp monster = target.GetComponent<MonsterHp>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            // ���� ����Ʈ ���� (���û���)
            if (thunderEffectPrefab != null)
            {
                GameObject effect  = Instantiate(thunderEffectPrefab, target.position, Quaternion.identity);

                Destroy(effect, 1f);
            }

            Debug.Log($"Thunder  {damage} ������");
        }
    }
 
    public void Skillset()
    {
        if (grade == SkillGrade.SSS)
        {
            Debug.Log("sss ����Դϴ�.");
            thunderMultiplier = 2.7f;
        }
        if (grade == SkillGrade.SS)
        {
            Debug.Log("ss ����Դϴ�.");
            thunderMultiplier = 2.5f;
        }
        if (grade == SkillGrade.S)
        {
            Debug.Log("s ����Դϴ�.");
            thunderMultiplier = 2.3f;
        }
        if (grade == SkillGrade.A)
        {
            Debug.Log("a ����Դϴ�.");
            thunderMultiplier = 2.1f;
        }
        if (grade == SkillGrade.B)
        {
            Debug.Log("b ����Դϴ�.");
            thunderMultiplier = 1.9f;
        }
        if (grade == SkillGrade.C)
        {
            Debug.Log("c ����Դϴ�.");
            thunderMultiplier = 1.7f;
        }
        if (grade == SkillGrade.D)
        {
            Debug.Log("d ����Դϴ�.");
            thunderMultiplier = 1.5f;
        }
        if (grade == SkillGrade.E)
        {
            Debug.Log("e ����Դϴ�.");
            thunderMultiplier = 1.3f;
        }
        if (grade == SkillGrade.F)
        {
            Debug.Log("f ����Դϴ�.");
            thunderMultiplier = 1.1f;
        }
    }
}
