using UnityEngine;

public class BuyButton : MonoBehaviour
{

    public SkillSlot[] slots;
    private SkillData[] allSkills;

    private SkillSlot selectedSlot;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private GameObject sellButton;

    void Start()
    {
        allSkills = Resources.LoadAll<SkillData>("Skills");
    }

    public void OnBuy()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].HasSkill())
            {
                var randomSkill = allSkills[Random.Range(0, allSkills.Length)];
                slots[i].SetSkill(randomSkill);

                break;
            }
        }
    }
    public void OnSell()
    {
        if (selectedSlot != null)
        {
            selectedSlot.ClearSkill();
            selectedSlot = null;
            ShowBuyButton(); // �ٽ� Buy ��ư���� ��ȯ
        }
    }

    public void OnSlotSelected(SkillSlot slot)
    {
        selectedSlot = slot;
        ShowSellButton(); // ���� Ŭ�� �� Sell ��ư Ȱ��ȭ
    }

    public void ShowBuyButton()
    {
        buyButton.SetActive(true);
        sellButton.SetActive(false);
    }

    public void ShowSellButton()
    {

        buyButton.SetActive(false);
        sellButton.SetActive(true);
    }
}
