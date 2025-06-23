//using UnityEngine;
//using System.Collections;
//using System.Threading;
//using TMPro;

//public class MonsterSpawn : MonoBehaviour
//{
//    //private Transform ptransform;
//    [SerializeField]
//    private GameObject monsterPrefab;
//    [SerializeField]
//    private GameObject point1;

//    [SerializeField]
//    private MonsterManager monsterManager;

//    public void SpawnMonster(int round)
//    {

//        GameObject monsterOb = Instantiate(monsterPrefab, point1.transform.position, Quaternion.identity);
 
//        MonsterHp monster = monsterOb.GetComponent<MonsterHp>();
 
//        monster.SetupStats(round);
 
//        monsterManager.IncreaseCount(); // ¼ö Áõ°¡
//    }
//}
