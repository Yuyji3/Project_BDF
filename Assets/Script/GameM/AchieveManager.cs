using UnityEngine;
using TMPro;
public class AchieveManager : MonoBehaviour
{

    public int killIndex; // 몬스터 킬 업적 단계
    [System.Serializable]
    public class KillAchievementInfo
    {
        public string name;   // "몬스터 100마리 처치"
        public int goal;
        public float achieve; // 보상

        public TextMeshProUGUI uiText; // 달성치
        public TextMeshProUGUI uiText2; // 업적이름
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
