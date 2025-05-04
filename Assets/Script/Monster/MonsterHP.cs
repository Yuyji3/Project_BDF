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
            Debug.LogError("hpFillImage�� ������� �ʾҽ��ϴ�!");
        }

        // ü�� �ʱ�ȭ�� SetupStats���� ����
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

        Debug.Log("�������� �Ծ����ϴ�.");
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
