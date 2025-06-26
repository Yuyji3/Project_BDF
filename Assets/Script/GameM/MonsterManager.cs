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
        // �ϳ��� �����ϵ��� ����
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject); // �� �Ѿ�� �����ϰ� ���� ���
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
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

        IncreaseCount(); // �� ����
    }

    public  void IncreaseCount()
    {
        monsterCount++;
        if (monsterCount >= maxCount)
        {
            Debug.Log("���� ����!");

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
