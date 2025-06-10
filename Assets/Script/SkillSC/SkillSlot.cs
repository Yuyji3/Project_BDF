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
        
        Debug.Log("�̹��� �ٲ�");

        if (!string.IsNullOrEmpty(skill.skillScriptTypeName))
        {
            System.Type skillType = System.Type.GetType(skill.skillScriptTypeName);

            // ��ũ��Ʈ�� �����ϰ� MonoBehaviour�� ���� ����
            if (skillType != null && skillType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                tower.AddComponent(skillType);
            }
            else
            {
                Debug.LogWarning($"'{skill.skillScriptTypeName}' Ÿ���� ã�� �� ���ų� MonoBehaviour�� �ƴմϴ�.");
            }
        }

    }

    public bool HasSkill() => currentSkill != null;
    public SkillData GetSkill() => currentSkill;
}