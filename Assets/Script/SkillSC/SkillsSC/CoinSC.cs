using System.Collections;
using UnityEditor;
using UnityEngine;

public class CoinSC : MonoBehaviour
{

    private float rotate=180f;

    private GameObject coinObject;

    public SkillGrade grade;

    
    public GameManager gameManager;

    public Button buttonManager;

    void Update()
    {

        if (coinObject != null)
        {
            coinObject.transform.Rotate(0, rotate * Time.deltaTime, 0);
        }

        grade = buttonManager.upgraded;


    }
    void Start()
    {

        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        gameManager = GameManager.Instance;

        GameObject _coinPrefeb = Resources.Load<GameObject>("Skills_Icon/Coin");

        coinObject = Instantiate(_coinPrefeb);
        coinObject.transform.position = new Vector3(transform.position.x,transform.position.y+0.4f,0);


        StartCoroutine(GoSkill());
    }
    public void Cleanup()
    {
        if (coinObject != null)
        {
            Destroy(coinObject);
        }
    }

    IEnumerator GoSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Skillset();
            yield return new WaitForSeconds(3f);
        }
        

    }
    public void Skillset()
    {
        if (grade == SkillGrade.SSS)
        {
            Debug.Log("sss 등급입니다.");
            gameManager.currentGold += 15f;
        }
        if (grade == SkillGrade.SS)
        {
            Debug.Log("ss 등급입니다.");
            gameManager.currentGold += 15f;
        }
        if (grade == SkillGrade.S)
        {
            Debug.Log("s 등급입니다.");
            gameManager.currentGold += 15f;
        }
        if (grade == SkillGrade.A) 
        {
            Debug.Log("a 등급입니다.");
            gameManager.currentGold += 15f; 
        }
        if(grade == SkillGrade.B)
        {
            Debug.Log("b 등급입니다.");
            gameManager.currentGold += 10f;
        }
        if (grade == SkillGrade.C)
        {
            Debug.Log("c 등급입니다.");
            gameManager.currentGold += 5f;
        }
        if (grade == SkillGrade.D)
        {
            Debug.Log("d 등급입니다.");
            gameManager.currentGold += 3f;
        }
        if (grade == SkillGrade.E)
        {
            Debug.Log("e 등급입니다.");
            gameManager.currentGold += 2f;
        }
        if (grade == SkillGrade.F)
        {
            Debug.Log("f 등급입니다.");
            gameManager.currentGold += 1f;
        }
    }
}
