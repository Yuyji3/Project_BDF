using UnityEngine;
using TMPro;
public class AchieveManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI monsterKill;

    private void Start()
    {
        UpdateMonsterKillUI();
    }
    public void UpdateMonsterKillUI()
    {
        monsterKill.text = $"{SaveManager.Instance.Data.monsterKillCount} / 100";
    }
}
