using UnityEngine;
using System.Collections;
using System.Threading;

public class MonsterSpawn : MonoBehaviour
{
    //private Transform ptransform;
    [SerializeField]
    private GameObject monsterPrefab;
    [SerializeField]
    private GameObject point1;

    public void SpawnMonster(int round)
    {

        GameObject monsterOb = Instantiate(monsterPrefab, point1.transform.position, Quaternion.identity);
 
        MonsterHp monster = monsterOb.GetComponent<MonsterHp>();
 
        monster.SetupStats(round);
 
        MonsterManager.IncreaseCount(); // ¼ö Áõ°¡
    }
}
