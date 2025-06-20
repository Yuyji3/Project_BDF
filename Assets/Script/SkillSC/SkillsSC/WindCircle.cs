using UnityEngine;

public class WindCircle : MonoBehaviour
{
    [SerializeField]
    private GameObject windCircle;
    public Button buttonManager;

    public SkillGrade grade;

    public float windAttack; // 공격력

    private int currentint3;
    private GameObject skillSpawn;


    void Start()
    {
        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        skillSpawn = Resources.Load<GameObject>("Skills_Prefab/WindCircle");

        currentint3 = buttonManager.currentInt3;

        Spawn();

        Skillset();
    }

    public void Spawn()
    {
        Vector3 skillSpawnpositon = skillSpawn.transform.position;

        if (skillSpawn != null)
        {
            skillSpawn = Instantiate(skillSpawn, skillSpawnpositon , Quaternion.identity);
            Debug.Log($"{skillSpawn} 스킬 오브젝트가 맵에 소환됨");
        }
        else
        {
            Debug.LogWarning("skelOB이 비어있음");
            
        }
    }

    public void Skillset()
    {

        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {
            Debug.Log("sss 등급입니다.");
            windAttack = 2.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {
            Debug.Log("ss 등급입니다.");
            windAttack = 2.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
            Debug.Log("s 등급입니다.");
            windAttack = 2.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {
            Debug.Log("a 등급입니다.");
            windAttack = 2.1f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {
            Debug.Log("b 등급입니다.");
            windAttack = 1.9f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
            Debug.Log("c 등급입니다.");
            windAttack = 1.7f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
            Debug.Log("d 등급입니다.");
            windAttack = 1.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
            Debug.Log("e 등급입니다.");
            windAttack = 1.3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {
            Debug.Log("f 등급입니다.");
            windAttack = 1.1f;
        }
    }
}
