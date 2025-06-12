using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour
{
    public int currentRound = 1;
    public int maxRound = 20;
    public int monstersPerRound = 20;
    public float spawnInterval = 1f;
    public MonsterSpawn spawner;

    void Start()
    {
        StartCoroutine(RoundLoop());


        
    }

    IEnumerator RoundLoop()
    {

        yield return new WaitForSeconds(5f);

        while (currentRound <= maxRound)
        {
            for (int i = 0; i < monstersPerRound; i++)
            {
                Debug.Log("1");
                spawner.SpawnMonster(currentRound);
                Debug.Log("2");
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(5f); // 라운드 간 텀 (옵션)
            currentRound++;
        }
    }
}