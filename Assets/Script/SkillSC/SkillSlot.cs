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

        if (!string.IsNullOrEmpty(skill.skillScriptTypeName))
        {
            System.Type skillType = System.Type.GetType(skill.skillScriptTypeName);

            // 스크립트가 존재하고 MonoBehaviour일 때만 실행
            if (skillType != null && skillType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                tower.AddComponent(skillType);
            }
            else
            {
                Debug.LogWarning($"'{skill.skillScriptTypeName}' 타입을 찾을 수 없거나 MonoBehaviour가 아닙니다.");
            }
        }

    }

    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}