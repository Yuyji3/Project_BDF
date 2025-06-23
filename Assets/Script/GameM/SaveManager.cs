using System.IO;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private const string FILE_NAME = "save.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, FILE_NAME);

    public GameSaveData Data { get; private set; } = new GameSaveData();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Load(); // 게임 데이터 불러오기!
            DontDestroyOnLoad(gameObject); // 씬 전환에도 살아남게
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 몬스터 킬수 증가
    public void AddMonsterKill(int amount = 1)
    {
        Data.monsterKillCount += amount;
        Save();
    }

    // 캠페인 클리어 횟수ㅜ 증가
    public void AddCampaignClear(int amount = 1)
    {
        Data.campaignClear += amount;
        Save();
    }

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
}
