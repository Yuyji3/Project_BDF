using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UIButton = UnityEngine.UI.Button;
public class AchieveManager : MonoBehaviour
{
    [SerializeField] private UIButton achieveButton;
   // [SerializeField]
   //// private Button achieveButton;

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
        // ��ư Ŭ�� ������ ����
        achieveButton.onClick.RemoveAllListeners();
        achieveButton.onClick.AddListener(ClaimAchievement);

        UpdateAllAchievementUIs();
    }
    public void UpdateAllAchievementUIs()
    {
        if (killIndex < 0 || killIndex >= achievements.Length)
        {
            // ��� ���� �Ϸ� ó��: ��ư ��Ȱ��ȭ
            achieveButton.interactable = false;
            achieveButton.image.color = Color.gray;
            return;
        }

        int killCount = SaveManager.Instance.Data.monsterKillCount;
        var info = achievements[killIndex];

        // 1) �ؽ�Ʈ ����
        info.uiText2.text = info.name;
        info.uiText.text = $"{killCount} / {info.goal}";

        // 2) ��ư Ȱ��/��Ȱ�� & ����
        bool canClaim = killCount >= info.goal && !info.isClaimed;
        achieveButton.interactable = canClaim;
        achieveButton.image.color = canClaim ? Color.white : Color.gray;
    }
    public void ClaimAchievement()
    {
        var info = achievements[killIndex];

        // ���� ����
        GameManager.Instance.currentBlue += info.achieve;
        info.isClaimed = true;

        // ���� �������� �̵�
        killIndex++;

        // UI ����
        UpdateAllAchievementUIs();
    }
}
