using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static int monsterCount = 0;
    public static int maxCount = 20;

    public TextMeshProUGUI counterText;

    public GameObject gameOver;

    void Update()
    {
        counterText.text = $"{GetCount()} / {maxCount}";

    }

    public  void IncreaseCount()
    {
        monsterCount++;
        if (monsterCount >= maxCount)
        {
            Debug.Log("게임 오버!");

            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public static void DecreaseCount()
    {
        monsterCount--;
    }

    public static int GetCount() => monsterCount;


}
