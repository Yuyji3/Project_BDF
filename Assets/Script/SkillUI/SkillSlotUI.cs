using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI upgradeText;

    public int slotIndex;

    private SkillData skill;



    public void Set(SkillData data)
    {
        skill = data;
        iconImage.sprite = data.icon;
        upgradeText.text = $"{data.level}";
    }

    
}
