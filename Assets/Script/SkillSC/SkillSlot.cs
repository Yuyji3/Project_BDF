using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Image iconImage;
    public SkillData currentSkill;

    [SerializeField]
    private GameObject tower;

    
    public void SetSkill(SkillData skill)
    {
     
        currentSkill = skill;
        iconImage.sprite = skill.icon;
        
        Debug.Log("이미지 바뀜");

        if (skill.skillPrefab != null)
        {
            CoinSC coinScript = tower.AddComponent<CoinSC>();
        }

    }

    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}