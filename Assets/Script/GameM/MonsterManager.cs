using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public  int monsterCount = 0;
    public  int maxCount = 20;

    public int monsterKill = 0;

    public TextMeshProUGUI counterText;

    public GameObject gameOver;

    [SerializeField]
    private GameObject monsterPrefab;
    [SerializeField]
    private GameObject point1;

    public static MonsterManager Instance { get; private set; }

    private void Awake()
    {
        // 하나만 존재하도록 보장
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지하고 싶을 경우
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void Update()
    {
        counterText.text = $"{GetCount()} / {maxCount}";

    }

    public void SpawnMonster(int round)
    {

        GameObject monsterOb = Instantiate(monsterPrefab, point1.transform.position, Quaternion.identity);

        MonsterHp monster = monsterOb.GetComponent<MonsterHp>();

        monster.SetupStats(round);

        IncreaseCount(); // 수 증가
    }

    public  void IncreaseCount()
    {
        monsterCount++;
        if (monsterCount >= maxCount)
        {
            Debug.Log("게임 오버!");

            SaveManager.Instance.AddMonsterKill(monsterKill);

            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void DecreaseCount()
    {
        monsterCount--;

        monsterKill++; 
    }

    public int GetCount() => monsterCount;


}
