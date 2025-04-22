using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour
{
    private Image hpFillImage; // Fill �̹���

    private float maxHp = 100f;
    private float currentHp;

    public float damage;
    void Start()
    {
        hpFillImage = GetComponentInChildren<Image>();
        if (hpFillImage == null) { Debug.Log("���� hp���� �ȵǾ� ����"); };

        currentHp = maxHp;
        UpdateHpUI();
    }
    private void Update()
    {
        TakeDamage(damage);
    }
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
        UpdateHpUI();

        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHpUI()
    {
        hpFillImage.fillAmount = currentHp / maxHp;
        
    }
}
