using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UIButton = UnityEngine.UI.Button;
public class AchieveManager : MonoBehaviour
{
    [SerializeField] private UIButton achieveButton;
   // [SerializeField]
   //// private Button achieveButton;

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
        // 버튼 클릭 리스너 연결
        achieveButton.onClick.RemoveAllListeners();
        achieveButton.onClick.AddListener(ClaimAchievement);

        UpdateAllAchievementUIs();
    }
    public void UpdateAllAchievementUIs()
    {
        if (killIndex < 0 || killIndex >= achievements.Length)
        {
            // 모든 업적 완료 처리: 버튼 비활성화
            achieveButton.interactable = false;
            achieveButton.image.color = Color.gray;
            return;
        }

        int killCount = SaveManager.Instance.Data.monsterKillCount;
        var info = achievements[killIndex];

        // 1) 텍스트 갱신
        info.uiText2.text = info.name;
        info.uiText.text = $"{killCount} / {info.goal}";

        // 2) 버튼 활성/비활성 & 색상
        bool canClaim = killCount >= info.goal && !info.isClaimed;
        achieveButton.interactable = canClaim;
        achieveButton.image.color = canClaim ? Color.white : Color.gray;
    }
    public void ClaimAchievement()
    {
        var info = achievements[killIndex];

        // 보상 지급
        GameManager.Instance.currentBlue += info.achieve;
        info.isClaimed = true;

        // 다음 업적으로 이동
        killIndex++;

        // UI 갱신
        UpdateAllAchievementUIs();
    }
}
