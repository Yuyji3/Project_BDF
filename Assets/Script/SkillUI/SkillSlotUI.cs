using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI skillname2;


    public int slotIndex;

    private SkillData skill;


    [SerializeField]
    private TextMeshProUGUI skillname;
    [SerializeField]
    private Image skillimage;
    [SerializeField]
    private TextMeshProUGUI skilltext;


    public void Set(SkillData data)
    {
        skill = data;
        iconImage.sprite = data.icon;
        skillname2.text = $"{skill.name}";
    }

    public void ShowSkillInfo()
    {
        Debug.Log("Å¬¸¯");
        skillimage.sprite = iconImage.sprite;
        skillname.text = $"{skill.name}";
        skilltext.text = $"{skill.skillex}";
    }
}
