using UnityEngine;
using System.Collections;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public int currentRound = 1;
    public int maxRound = 20;
    public int monstersPerRound = 40;
    public float spawnInterval = 1f;
    public MonsterSpawn spawner;

    public TextMeshProUGUI timerText;
    private float roundTimer = 60f;
    private bool timerActive = false;

    public TextMeshProUGUI roundText;
    void Start()
    {
        StartCoroutine(RoundLoop());
    }

    void Update()
    {
        if (timerActive)
        {
            roundTimer -= Time.deltaTime;
            if (roundTimer < 0) roundTimer = 0;

            int minutes = Mathf.FloorToInt(roundTimer / 60);
            int seconds = Mathf.FloorToInt(roundTimer % 60);
            timerText.text = $"{minutes:0}:{seconds:00}";
        }
    }

    IEnumerator RoundLoop()
    {

        yield return new WaitForSeconds(5f);

        while (currentRound <= maxRound)
        {
            roundText.text = $"{currentRound} Round";

            // 타이머 시작
            roundTimer = 60f;
            timerActive = true;

            // 40초 동안 1초마다 몬스터 소환
            for (int i = 0; i < monstersPerRound; i++)
            {
                spawner.SpawnMonster(currentRound);
                yield return new WaitForSeconds(spawnInterval);
            }

            // 20초 대기
            yield return new WaitForSeconds(20f);

            // 타이머 멈춤 & 0:00 표시
            timerActive = false;
            timerText.text = "0:00";

            currentRound++;

            
        }
    }
}
