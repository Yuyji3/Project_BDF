using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour
{
    public Image iconImage;
    public SkillData currentSkill;

    //���� ��ų���� ��ȣ
    public int currentInt;

    [SerializeField] 
    private GameObject tower;


    //�޾ƿ� ���
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
                // ��ũ��Ʈ �߰�
                Component comp = tower.AddComponent(skillType);

                // grade �ʵ带 ã�Ƽ� �� ����
                FieldInfo gradeField = skillType.GetField("grade", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                if (gradeField != null && gradeField.FieldType == typeof(SkillGrade))
                {
                    gradeField.SetValue(comp, grade);
                }
                else
                {
                    Debug.LogWarning($"{skillType.Name} ��ũ��Ʈ�� grade �ʵ� ����");
                }
            }
            else
            {
                Debug.LogWarning($"'{skill.skillScriptTypeName}' Ÿ���� ���ų� MonoBehaviour �ƴ�");
            }
        }
    }

    public void ClearSkill()
    {
        if (currentSkill == null) return;

 

        // 1. ��ų ��ũ��Ʈ ����
        if (!string.IsNullOrEmpty(currentSkill.skillScriptTypeName))
        {
            System.Type skillType = System.Type.GetType(currentSkill.skillScriptTypeName);
            if (skillType != null)
            {
                //  ������Ʈ ����
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
