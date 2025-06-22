using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private const string FILE_NAME = "save.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, FILE_NAME);

    public GameSaveData Data { get; private set; } = new GameSaveData();

    #region 싱글턴 + 로드
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();          //  게임 켤 때 딱 1번
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
    #endregion

    #region 퍼블릭 API
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
        Debug.Log($"저장 완료: {FilePath}\n{json}");
#endif
    }

    public void Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            Data = JsonUtility.FromJson<GameSaveData>(json);
#if UNITY_EDITOR
            Debug.Log($"불러오기 완료: {FilePath}\n{json}");
#endif
        }
        else
        {
            Data = new GameSaveData(); // 첫 실행 시 기본값 0,0
            Save();                // 빈 세이브 파일 생성
        }
    }
    #endregion
}
