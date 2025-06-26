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

    //��ų���� ���������� �Ѱ��� ��ȣ
    public int currentInt2;
    //��ų ��ȯ������ �Ѱ��� ��ȣ
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
                    currentInt3 = i;
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
            Debug.Log("�̹� �ְ� ����Դϴ�.");
            return;
        }

        if (gameManager.currentGold < costmenual.upCost)
        {
            Debug.Log("���� �����մϴ�");
            return;
        }

  

        upgraded = (SkillGrade)((int)currentGrade + 1);

        slots[currentInt2].grade = upgraded;

        


        gradeImg.showgrade();

        
        gameManager.currentGold -= costmenual.upCost;

        costmenual.showcost();

        Debug.Log("���׷��̵� �Ϸ�: " + upgraded);
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

