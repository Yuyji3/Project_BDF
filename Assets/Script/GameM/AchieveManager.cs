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
        public bool isClaimed; // ���� ���� ����

        public TextMeshProUGUI uiText; // �޼�ġ
        public TextMeshProUGUI uiText2; // �����̸�
    }

    public KillAchievementInfo[] achievements;

    void Start()
    {
        UpdateAllAchievementUIs();
    }
    public void UpdateAllAchievementUIs()
    {
        int killCount = SaveManager.Instance.Data.monsterKillCount;

        achievements[killIndex].uiText2.text = $" {achievements[killIndex].name}";
        achievements[killIndex].uiText.text = $"{killCount} / {achievements[killIndex].goal}";

        if (achievements[killIndex].goal <= killCount && !achievements[killIndex].isClaimed)
        {
            gameObject.SetActive(true);

            achievements[killIndex].isClaimed = true; // ���� �Ϸ� ó��

            GameManager.Instance.currentBlue += achievements[killIndex].achieve;

            killIndex++;

            UpdateAllAchievementUIs(); // ���� �ݺ���

        }

        gameObject.SetActive(false);

    }
}
