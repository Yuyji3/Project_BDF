using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private const string FILE_NAME = "save.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, FILE_NAME);

    public GameSaveData Data { get; private set; } = new GameSaveData();

    #region �̱��� + �ε�
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();          //  ���� �� �� �� 1��
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }
    #endregion

    #region �ۺ� API
    public void AddMonsterKill(int amount = 1)
    {
        Data.monsterKillCount += amount;
        Save();
    }

    public void AddCampaignClear(int amount = 1)
    {
        Data.campaignClear += amount;
        Save();
    }
    #endregion

    #region Save / Load
    public void Save()
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(FilePath, json);
#if UNITY_EDITOR
        Debug.Log($"���� �Ϸ�: {FilePath}\n{json}");
#endif
    }

    public void Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            Data = JsonUtility.FromJson<GameSaveData>(json);
#if UNITY_EDITOR
            Debug.Log($"�ҷ����� �Ϸ�: {FilePath}\n{json}");
#endif
        }
        else
        {
            Data = new GameSaveData(); // ù ���� �� �⺻�� 0,0
            Save();                // �� ���̺� ���� ����
        }
    }
    #endregion
}
