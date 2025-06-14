using UnityEngine;

public class ThunderSC : MonoBehaviour
{
    public float triggerChance = 0.3f; // 30% 확률로 발동

    public GameObject thunderEffectPrefab; // 시각효과(옵션)
    public float thunderMultiplier = 1.5f;  // 공격력 계수

    private void OnEnable()
    {
        Tower.OnAttack += AttackThunder; // 이벤트 구독
    }

    private void OnDisable()
    {
        Tower.OnAttack -= AttackThunder; // 해제
    }

    public void AttackThunder(Transform target)
    {
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
                Instantiate(thunderEffectPrefab, target.position, Quaternion.identity);

                Destroy(thunderEffectPrefab,1f);
            }

            Debug.Log($"Thunder  {damage} 데미지");
        }
    }
}
