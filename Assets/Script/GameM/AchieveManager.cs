using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UIButton = UnityEngine.UI.Button;
using Unity.Android.Gradle.Manifest;
public class AchieveManager : MonoBehaviour
{
    [SerializeField] private UIButton[] achieveButton;

    [System.Serializable]
    public class KillAchievementInfo
    {
        public string name;   // "몬스터 100마리 처치"
        public int goal;
        public int achieve; // 보상
        public bool isClaimed; // 보상 수령 여부

        public TextMeshProUGUI uiText; // 달성치
        public TextMeshProUGUI uiText2; // 업적이름
    }

    public KillAchievementInfo[] achievements;
    public KillAchievementInfo[] campaignAchievements;

    private int killIndex; // 몬스터 킬 업적 단계
    private int campaignIndex; // 몬스터 킬 업적 단계

    void Start()
    {
        killIndex = SaveManager.Instance.Data.monsterKillCountindex; //몬스터 업적
        campaignIndex = SaveManager.Instance.Data.campaignClearindex; //캠페인 클리어 횟수 업적

        achieveButton[0].onClick.AddListener(ClaimKillAchievement);
        achieveButton[1].onClick.AddListener(ClaimCampaignClearAchievement);


        UpdateKllAchievementUIs();
        UpdateCampaignClearAchievementUIs();
    }

    #region 몬스터 킬 업적
    public void UpdateKllAchievementUIs()
    {
        if (killIndex < 0 || killIndex >= achievements.Length)
        {
            // 모든 업적 완료 처리: 버튼 비활성화
            achieveButton[0].interactable = false;
            achieveButton[0].image.color = Color.gray;
            return;
        }

        int killCount = SaveManager.Instance.Data.monsterKillCount;
        var info = achievements[killIndex];

        // 1) 텍스트 갱신
        info.uiText2.text = info.name;
        info.uiText.text = $"{killCount} / {info.goal}";

        // 2) 버튼 활성/비활성 & 색상
        bool canClaim = killCount >= info.goal &&!info.isClaimed;
        achieveButton[0].interactable = canClaim;
        achieveButton[0].image.color = canClaim ? Color.white : Color.gray;
    }
    public void ClaimKillAchievement()
    {
        var info = achievements[killIndex];

        SaveManager.Instance.Data.blueCrystal += info.achieve;


        Debug.Log(SaveManager.Instance.Data.blueCrystal);

        info.isClaimed = true;
        // 다음 업적으로 이동
        killIndex++;
        SaveManager.Instance.Data.monsterKillCountindex = killIndex;

        SaveManager.Instance.Save();
        GameManager.Instance.CashReflash();

        // UI 갱신
        UpdateKllAchievementUIs();
    }

    #endregion

    #region 캠페인 클리어 업적
    public void UpdateCampaignClearAchievementUIs()
    {
        if (campaignIndex < 0 || campaignIndex >= campaignAchievements.Length)
        {
            // 모든 업적 완료 처리: 버튼 비활성화
            achieveButton[1].interactable = false;
            achieveButton[1].image.color = Color.gray;
            return;
        }

        int CClearCount = SaveManager.Instance.Data.campaignClear;
        var info = campaignAchievements[campaignIndex];

        // 1) 텍스트 갱신
        info.uiText2.text = info.name;
        info.uiText.text = $"{CClearCount} / {info.goal}";

        // 2) 버튼 활성/비활성 & 색상
        bool canClaim = CClearCount >= info.goal && !info.isClaimed;
        achieveButton[1].interactable = canClaim;
        achieveButton[1].image.color = canClaim ? Color.white : Color.gray;
    }
    public void ClaimCampaignClearAchievement()
    {
        var info = campaignAchievements[campaignIndex];

        SaveManager.Instance.Data.blueCrystal += info.achieve;


        Debug.Log(SaveManager.Instance.Data.blueCrystal);

        info.isClaimed = true;
        // 다음 업적으로 이동
        campaignIndex++;
        SaveManager.Instance.Data.campaignClearindex = campaignIndex;

        SaveManager.Instance.Save();
        GameManager.Instance.CashReflash();

        // UI 갱신
        UpdateCampaignClearAchievementUIs();
    }
    #endregion
}

