using UnityEngine;

public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% Ȯ���� �ߵ�

    public GameObject thunderEffectPrefab; // �ð�ȿ��(�ɼ�)
    public float thunderMultiplier = 1.5f;  // ���ݷ� ���

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // �̺�Ʈ ����
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // ����
    }

    public void AttackThunder(Transform target)
    {
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
                Instantiate(thunderEffectPrefab, target.position, Quaternion.identity);

                Destroy(thunderEffectPrefab,1f);
            }

            Debug.Log($"Thunder  {damage} ������");
        }
    }
}
