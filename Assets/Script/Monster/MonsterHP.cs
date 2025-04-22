using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour
{
    private Image hpFillImage; // Fill 이미지

    private float maxHp = 100f;
    private float currentHp;

    public float damage;
    void Start()
    {
        hpFillImage = GetComponentInChildren<Image>();
        if (hpFillImage == null) { Debug.Log("현재 hp설정 안되어 있음"); };

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
