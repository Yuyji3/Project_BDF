using UnityEngine;
using System.Collections;
public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% Ȯ���� �ߵ�

    //private GameObject EffectPrefab; // �ð�ȿ��(�ɼ�)
    public float thunderMultiplier = 0;  // ���ݷ� ���

    public SkillGrade grade;

    public Button buttonManager;

    private int currentint3;

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // �̺�Ʈ ����
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // ����
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

            // ������ ����
            MonsterHp monster = target.GetComponent<MonsterHp>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            // ���� ����Ʈ ���� (���û���)


            GameObject effect = PoolManager.Instance.SpawnFromPool("Thunder", target.position, Quaternion.identity);

            StartCoroutine(ReturnEffectToPool(effect));
            

            Debug.Log($"Thunder  {damage} ������");
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
            Debug.Log("��� sss ����Դϴ�.");
            thunderMultiplier = 2.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {
            Debug.Log("���ss ����Դϴ�.");
            thunderMultiplier = 2.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
            Debug.Log("���s ����Դϴ�.");
            thunderMultiplier = 2.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {
            Debug.Log("���a ����Դϴ�.");
            thunderMultiplier = 2.1f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {
            Debug.Log("���b ����Դϴ�.");
            thunderMultiplier = 1.9f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
            Debug.Log("���c ����Դϴ�.");
            thunderMultiplier = 1.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
            Debug.Log("���d ����Դϴ�.");
            thunderMultiplier = 1.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
            Debug.Log("���e ����Դϴ�.");
            thunderMultiplier = 1.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {
            Debug.Log("���f ����Դϴ�.");
            thunderMultiplier = 1.1f;
        }
    }
}
