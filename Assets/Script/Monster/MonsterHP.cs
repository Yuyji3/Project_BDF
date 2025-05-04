using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour
{
    [SerializeField] private Image hpFillImage;

    private float maxHp = 2f;
    private float currentHp;
    public float damage = 0;

    void Start()
    {
        if (hpFillImage == null)
        {
            Debug.LogError("hpFillImage가 연결되지 않았습니다!");
        }

        // 체력 초기화는 SetupStats에서 수행
    }

    void Update()
    {
        if (damage > 0)
            TakeDamage(damage);
    }

    public void SetupStats(int round)
    {
        maxHp = 2f * Mathf.Pow(1.2f, round - 1);
        currentHp = maxHp;
        UpdateHpUI();
    }

    public void TakeDamage(float damage)
    {

        Debug.Log("데미지를 입었습니다.");
        currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
        UpdateHpUI();

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHpUI()
    {
        if (hpFillImage != null)
            hpFillImage.fillAmount = currentHp / maxHp;
    }

    void OnDestroy()
    {
        MonsterManager.DecreaseCount();
    }
}
