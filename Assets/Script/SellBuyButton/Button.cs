using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public SkillSlot[] slots;
    private SkillData[] allSkills;

    [SerializeField]
    private SkillSlot currentSkill2;

    //현재 스킬슬롯 번호
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
            // 현재 슬롯에 들어 있는 스킬을 배열로 수집
            SkillData[] usedSkills = new SkillData[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].HasSkill())
                {
                    usedSkills[i] = slots[i].GetSkill();
                }
            }

            // 중복되지 않은 스킬을 리스트로 만들기
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

            // 사용할 수 있는 스킬이 없으면 종료
            if (availableSkills.Count == 0)
            {
                Debug.Log("모든 스킬을 이미 보유 중입니다.");
                return;
            }

            // 비어있는 슬롯에만 랜덤 스킬 적용
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
        else { Debug.Log("돈 부족"); }
    }
    public void OnSell()
    {
        if (slots[currentInt2] != null)
        {
            slots[currentInt2].ClearSkill();
            //slots[currentInt2] = null;

            gameManager.currentGold += 50f;

            ShowBuyButton(); // 다시 Buy 버튼으로 전환
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
