using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public SkillSlot[] slots;
    private SkillData[] allSkills;

    [SerializeField]
    private SkillSlot currentSkill2;

    //���� ��ų���� ��ȣ
    public int currentInt2;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private GameObject SellUpgradeButton;

    [SerializeField]
    private GameManager gameManager;
    
    void Start()
    {
        allSkills = Resources.LoadAll<SkillData>("Skills");

        gameManager = GameManager.Instance;
    }

    public void OnBuy()
    {
        if(gameManager.currentGold >= 100f)
        {
            gameManager.currentGold -= 100f;
            // ���� ���Կ� ��� �ִ� ��ų�� �迭�� ����
            SkillData[] usedSkills = new SkillData[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].HasSkill())
                {
                    usedSkills[i] = slots[i].GetSkill();
                }
            }

            // �ߺ����� ���� ��ų�� ����Ʈ�� �����
            List<SkillData> availableSkills = new List<SkillData>();
            for (int i = 0; i < allSkills.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < usedSkills.Length; j++)
                {
                    if (usedSkills[j] == allSkills[i])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    availableSkills.Add(allSkills[i]);
                }
            }

            // ����� �� �ִ� ��ų�� ������ ����
            if (availableSkills.Count == 0)
            {
                Debug.Log("��� ��ų�� �̹� ���� ���Դϴ�.");
                return;
            }

            // ����ִ� ���Կ��� ���� ��ų ����
            for (int i = 0; i < slots.Length; i++)
            {
                if (!slots[i].HasSkill())
                {
                    SkillData randomSkill = availableSkills[Random.Range(0, availableSkills.Count)];
                    slots[i].SetSkill(randomSkill);
                    break;
                }
            }
        }
        else { Debug.Log("�� ����"); }
    }
    public void OnSell()
    {
        if (slots[currentInt2] != null)
        {
            slots[currentInt2].ClearSkill();
            //slots[currentInt2] = null;

            gameManager.currentGold += 50f;

            ShowBuyButton(); // �ٽ� Buy ��ư���� ��ȯ
        }
    }

    public void OnSlotSelected(SkillSlot slot)
    {
        currentInt2 = slot.currentInt;
   
    }

    public void ShowBuyButton()
    {
        buyButton.SetActive(true);
        SellUpgradeButton.SetActive(false);
    }

    public void ShowSellButton()
    {
    
        if (slots[currentInt2].HasSkill())
        {
            buyButton.SetActive(false);
            SellUpgradeButton.SetActive(true);
        }

 
    }
}
