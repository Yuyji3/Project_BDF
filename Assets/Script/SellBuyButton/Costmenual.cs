using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class Costmenual : MonoBehaviour
{

    public TextMeshProUGUI costText;

    [SerializeField]
    private Button button;

    private int currentint2;

    public int upCost;


    public void showcost()
    {
        currentint2 = button.currentInt2;

        if (button.slots[currentint2].grade == SkillGrade.SSS)
        {
            costText.text = $"Full Upgrade";

        }
        if (button.slots[currentint2].grade == SkillGrade.SS)
        {
            costText.text = $"Upgrade Cost = 5000";
            upCost = 5000;
            
        }
        if (button.slots[currentint2].grade == SkillGrade.S)
        {
            costText.text = $"Upgrade Cost = 4000";
            upCost = 4000;
        }
        if (button.slots[currentint2].grade == SkillGrade.A)
        {
            costText.text = $"Upgrade Cost = 3000";
            upCost = 3000;

        }
        if (button.slots[currentint2].grade == SkillGrade.B)
        {
            costText.text = $"Upgrade Cost = 2000";
            upCost = 2000;
        }
        if (button.slots[currentint2].grade == SkillGrade.C)
        {   
            costText.text = $"Upgrade Cost = 1000";
            upCost = 1000;
        }
        if (button.slots[currentint2].grade == SkillGrade.D)
        {
            costText.text = $"Upgrade Cost = 500";
            upCost = 500;
        }
        if (button.slots[currentint2].grade == SkillGrade.E)
        {
            costText.text = $"Upgrade Cost = 400";
            upCost = 400;
        }
        if (button.slots[currentint2].grade == SkillGrade.F)
        {
            costText.text = $"Upgrade Cost = 100";
            upCost = 100;
        }
    }
}
