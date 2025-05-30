using UnityEngine;

public class BuyButton : MonoBehaviour
{

    public SkillSlot[] slots;
    private SkillData[] allSkills;

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
                Debug.Log("이미지 변경");
                break;
            }
        }
    }
}
