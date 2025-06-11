using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour
{
    public Image iconImage;
    public SkillData currentSkill;

    [SerializeField] private GameObject tower;
    [SerializeField] private GradeProbabilityData gradeData;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private GameObject sellButton;

    public bool IsSelected { get; private set; }

    public void SetSkill(SkillData skill)
    {
        currentSkill = skill;
        iconImage.sprite = skill.icon;

        SkillGrade grade = SkillGradeUtil.GetRandomGrade(gradeData);

        if (!string.IsNullOrEmpty(skill.skillScriptTypeName))
        {
            Type skillType = Type.GetType(skill.skillScriptTypeName);

            if (skillType != null && skillType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                // 스크립트 추가
                Component comp = tower.AddComponent(skillType);

                // grade 필드를 찾아서 값 주입
                FieldInfo gradeField = skillType.GetField("grade", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                if (gradeField != null && gradeField.FieldType == typeof(SkillGrade))
                {
                    gradeField.SetValue(comp, grade);
                }
                else
                {
                    Debug.LogWarning($"{skillType.Name} 스크립트에 grade 필드 없음");
                }
            }
            else
            {
                Debug.LogWarning($"'{skill.skillScriptTypeName}' 타입이 없거나 MonoBehaviour 아님");
            }
        }
    }
    public void ClearSkill()
    {
        if (currentSkill != null)
        {
            // 스킬 스크립트 제거
            if (!string.IsNullOrEmpty(currentSkill.skillScriptTypeName))
            {
                System.Type skillType = System.Type.GetType(currentSkill.skillScriptTypeName);
                if (skillType != null && skillType.IsSubclassOf(typeof(MonoBehaviour)))
                {
                    var existing = tower.GetComponent(skillType);
                    if (existing != null)
                        Destroy(existing);
                }
            }
        }

        currentSkill = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
        IsSelected = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IsSelected = true;

        

    }
    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}
