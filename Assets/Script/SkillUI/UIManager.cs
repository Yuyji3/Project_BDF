using System.Linq;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public SkillSlotUI[] slots; // 에디터에서 6개 슬롯 미리 연결

    void Start()
    {
        SkillData[] allSkills = Resources.LoadAll<SkillData>("Skills");

        // 정렬: slotIndex 기준으로 확실하게 정렬 (순서 보장)
        var sortedSkills = allSkills.OrderBy(s => s.skillnumber).ToArray();

        for (int i = 0; i < slots.Length && i < sortedSkills.Length; i++)
        {
            slots[i].Set(sortedSkills[i]);
        }
    }
}
