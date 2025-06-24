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
        public string name;   // "���� 100���� óġ"
        public int goal;
        public int achieve; // ����
        public bool isClaimed; // ���� ���� ����

        public TextMeshProUGUI uiText; // �޼�ġ
        public TextMeshProUGUI uiText2; // �����̸�
    }

    public KillAchievementInfo[] achievements;
    public KillAchievementInfo[] campaignAchievements;

    private int killIndex; // ���� ų ���� �ܰ�
    private int campaignIndex; // ���� ų ���� �ܰ�

    void Start()
    {
        killIndex = SaveManager.Instance.Data.monsterKillCountindex; //���� ����
        campaignIndex = SaveManager.Instance.Data.campaignClearindex; //ķ���� Ŭ���� Ƚ�� ����

        achieveButton[0].onClick.AddListener(ClaimKillAchievement);
        achieveButton[1].onClick.AddListener(ClaimCampaignClearAchievement);


        UpdateKllAchievementUIs();
        UpdateCampaignClearAchievementUIs();
    }

    #region ���� ų ����
    public void UpdateKllAchievementUIs()
    {
        if (killIndex < 0 || killIndex >= achievements.Length)
        {
            // ��� ���� �Ϸ� ó��: ��ư ��Ȱ��ȭ
            achieveButton[0].interactable = false;
            achieveButton[0].image.color = Color.gray;
            return;
        }

        int killCount = SaveManager.Instance.Data.monsterKillCount;
        var info = achievements[killIndex];

        // 1) �ؽ�Ʈ ����
        info.uiText2.text = info.name;
        info.uiText.text = $"{killCount} / {info.goal}";

        // 2) ��ư Ȱ��/��Ȱ�� & ����
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
        // ���� �������� �̵�
        killIndex++;
        SaveManager.Instance.Data.monsterKillCountindex = killIndex;

        SaveManager.Instance.Save();
        GameManager.Instance.CashReflash();

        // UI ����
        UpdateKllAchievementUIs();
    }

    #endregion

    #region ķ���� Ŭ���� ����
    public void UpdateCampaignClearAchievementUIs()
    {
        if (campaignIndex < 0 || campaignIndex >= campaignAchievements.Length)
        {
            // ��� ���� �Ϸ� ó��: ��ư ��Ȱ��ȭ
            achieveButton[1].interactable = false;
            achieveButton[1].image.color = Color.gray;
            return;
        }

        int CClearCount = SaveManager.Instance.Data.campaignClear;
        var info = campaignAchievements[campaignIndex];

        // 1) �ؽ�Ʈ ����
        info.uiText2.text = info.name;
        info.uiText.text = $"{CClearCount} / {info.goal}";

        // 2) ��ư Ȱ��/��Ȱ�� & ����
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
        // ���� �������� �̵�
        campaignIndex++;
        SaveManager.Instance.Data.campaignClearindex = campaignIndex;

        SaveManager.Instance.Save();
        GameManager.Instance.CashReflash();

        // UI ����
        UpdateCampaignClearAchievementUIs();
    }
    #endregion
}

