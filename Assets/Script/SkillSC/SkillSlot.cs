using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour
{
    public Image iconImage;
    public SkillData currentSkill;

    //현재 스킬슬롯 번호
    public int currentInt;

    [SerializeField] 
    private GameObject tower;


    //받아온 등급
    [SerializeField]
    private GradeProbabilityData gradeData;

    public SkillGrade grade;

    [SerializeField]
    private Sprite skillIcon;

    [SerializeField]
    private Button button;

    public bool IsSelected { get; private set; }

    public void SetSkill(SkillData skill)
    {
        currentSkill = skill;

        iconImage.sprite = skill.icon;

        grade = SkillGradeUtil.GetRandomGrade(gradeData);

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
        if (currentSkill == null) return;

 

        // 1. 스킬 스크립트 제거
        if (!string.IsNullOrEmpty(currentSkill.skillScriptTypeName))
        {
            System.Type skillType = System.Type.GetType(currentSkill.skillScriptTypeName);
            if (skillType != null)
            {
                //  오브젝트 정리
                var comp = tower.GetComponent(skillType);
                if (comp != null)
                {
                    var cleanupMethod = skillType.GetMethod("Cleanup");
                    if (cleanupMethod != null)
                        cleanupMethod.Invoke(comp, null);

                    Destroy(comp);
                }
            }
        }



        if (button.currentInt2 == currentInt)
        {
            iconImage.sprite = skillIcon;
            currentSkill = null;
        }
        

        IsSelected = false;
    }

  
    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}
