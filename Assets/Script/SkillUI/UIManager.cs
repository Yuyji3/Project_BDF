using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class SkillUIManager : MonoBehaviour
{
    public SkillSlotUI[] slots; // �����Ϳ��� 6�� ���� �̸� ����
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

        // ����: slotIndex �������� Ȯ���ϰ� ���� (���� ����)
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
