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
        public bool isClaimed; // 보상 수령 여부

        public TextMeshProUGUI uiText; // 달성치
        public TextMeshProUGUI uiText2; // 업적이름
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

            achievements[killIndex].isClaimed = true; // 수령 완료 처리

            GameManager.Instance.currentBlue += achievements[killIndex].achieve;

            killIndex++;

            UpdateAllAchievementUIs(); // 문제 반복됨

        }

        gameObject.SetActive(false);

    }
}
