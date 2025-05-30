using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Image iconImage;
    public SkillData currentSkill;

    public void SetSkill(SkillData skill)
    {
        //iconImage.enabled = true;
        currentSkill = skill;
        iconImage.sprite = skill.icon;
        
        Debug.Log("ÀÌ¹ÌÁö ¹Ù²ñ");
        
    }

    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}