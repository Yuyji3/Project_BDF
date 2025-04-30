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
            Debug.Log("���� ����!");
            // ���� ���� ó��
        }
    }

    public static void DecreaseCount()
    {
        monsterCount--;
    }

    public static int GetCount() => monsterCount;
}
