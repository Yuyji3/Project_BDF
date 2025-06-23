using UnityEngine;
using TMPro;
public class AchieveManager : MonoBehaviour
{

    public int killIndex; // ���� ų ���� �ܰ�
    [System.Serializable]
    public class KillAchievementInfo
    {
        public string name;   // "���� 100���� óġ"
        public int goal;
        public float achieve; // ����

        public TextMeshProUGUI uiText; // �޼�ġ
        public TextMeshProUGUI uiText2; // �����̸�
    }

    public KillAchievementInfo[] achievements;
    private void Start()
    {
        UpdateAllAchievementUIs();
    }

    public void UpdateAllAchievementUIs()
    {
        int killCount = SaveManager.Instance.Data.monsterKillCount;

        achievements[killIndex].uiText2.text = $" {achievements[killIndex].name}";
        achievements[killIndex].uiText2.text = $"{killCount} / {achievements[killIndex].goal}";

        if (achievements[killIndex].goal <= killCount)
        {
            GameManager.Instance.currentBlue += achievements[killIndex].achieve;

            killIndex++;
        }


    }
}
