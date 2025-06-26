using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class SkillUIManager : MonoBehaviour
{
    public SkillSlotUI[] slots; // 에디터에서 6개 슬롯 미리 연결
   //public SkillSlot slot;


    [SerializeField]
    private TextMeshProUGUI skillname;
    [SerializeField]
    private Image skillimage;
    [SerializeField]
    private TextMeshProUGUI skilltext;

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
    public void ShowSkillInfo(SkillSlotUI skillindex)
    {
        int index = skillindex.slotIndex;

        skillname.text = slots[index].name
        skillimage.sprite = slots[index].iconImage.sprite;
    }
}
