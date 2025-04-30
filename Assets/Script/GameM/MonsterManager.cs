using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static int monsterCount = 0;
    public static int maxCount = 20;

    public static void IncreaseCount()
    {
        monsterCount++;
        if (monsterCount >= maxCount)
        {
            Debug.Log("게임 오버!");
            // 게임 오버 처리
        }
    }

    public static void DecreaseCount()
    {
        monsterCount--;
    }

    public static int GetCount() => monsterCount;
}
