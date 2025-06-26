using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{

    public SkillSlot[] slots;
    private SkillData[] allSkills;

    public  SkillSlot currentSkill2;

   
    public SkillGrade upgraded;
    SkillGrade currentGrade;

    //스킬슬롯 선택했을대 넘겨줄 번호
    public int currentInt2;
    //스킬 소환했을때 넘겨줄 번호
    public int currentInt3;

    //[SerializeField]
    //private GameObject buyButton;

    [SerializeField]
    private GameObject SellUpgradeButton;

    private GameManager gameManager;

    [SerializeField]
    private GradeImg gradeImg;

    [SerializeField]
    private Costmenual costmenual;


    [SerializeField]
    private TextMeshProUGUI speedButton;

    void Start()
    {
        allSkills = Resources.LoadAll<SkillData>("Skills");

        gameManager = GameManager.Instance;
    }

    public void OnBuy()
    {
        costmenual.showcost();

        if (gameManager.currentGold >= 100f)
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
                    currentInt3 = i;
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
        //buyButton.SetActive(true);
        SellUpgradeButton.SetActive(false);
    }

    public void ShowSellButton()
    {
    
        if (slots[currentInt2].HasSkill())
        {
            //buyButton.SetActive(false);
            SellUpgradeButton.SetActive(true);

            gradeImg.showgrade();
            costmenual.showcost();
        }
    }
    public void show(GameObject button1)
    {
        button1.SetActive(true);
    }
    public void back(GameObject button2)
    {
        button2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeButton()
    {

        currentGrade = slots[currentInt2].grade;
        int maxIndex = System.Enum.GetValues(typeof(SkillGrade)).Length - 1;

        if ((int)currentGrade >= maxIndex)
        {
            Debug.Log("이미 최고 등급입니다.");
            return;
        }

        if (gameManager.currentGold < costmenual.upCost)
        {
            Debug.Log("돈이 부족합니다");
            return;
        }

  

        upgraded = (SkillGrade)((int)currentGrade + 1);

        slots[currentInt2].grade = upgraded;

        


        gradeImg.showgrade();

        
        gameManager.currentGold -= costmenual.upCost;

        costmenual.showcost();

        Debug.Log("업그레이드 완료: " + upgraded);
    }

    public void settingButton()
    {
        //settingUI.SetActive(true);

        Time.timeScale = 0f;
    }

    private bool isSpeedUp = false;

    public void onClickSpeedButton()
    {
        isSpeedUp = !isSpeedUp;
        if (isSpeedUp)
        {
            speedButton.text = "x2";
            Time.timeScale = 2f;
        }
        else
        {
            speedButton.text = "x1";
            Time.timeScale = 1f;
        }
    }
}

