using System.Linq;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public SkillSlotUI[] slots; // �����Ϳ��� 6�� ���� �̸� ����

    void Start()
    {
        SkillData[] allSkills = Resources.LoadAll<SkillData>("Skills");

        // ����: slotIndex �������� Ȯ���ϰ� ���� (���� ����)
        var sortedSkills = allSkills.OrderBy(s => s.skillnumber).ToArray();

        for (int i = 0; i < slots.Length && i < sortedSkills.Length; i++)
        {
            slots[i].Set(sortedSkills[i]);
        }
    }
}
