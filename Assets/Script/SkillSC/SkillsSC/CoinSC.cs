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

    private int currentint3;

    void Update()
    {

        if (coinObject != null)
        {
            coinObject.transform.Rotate(0, rotate * Time.deltaTime, 0);
        }
    }
    void Start()
    {

        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        currentint3 = buttonManager.currentInt3;

        gameManager = GameManager.Instance;

        GameObject _coinPrefeb = Resources.Load<GameObject>("Skills_Prefab/Coin");

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

        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {

            gameManager.currentGold += 15f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {

            gameManager.currentGold += 15f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {

            gameManager.currentGold += 15f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A) 
        {

            gameManager.currentGold += 15f; 
        }
        if(buttonManager.slots[currentint3].grade == SkillGrade.B)
        {

            gameManager.currentGold += 10f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
    
            gameManager.currentGold += 5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {

            gameManager.currentGold += 3f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
    
            gameManager.currentGold += 2f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {

            gameManager.currentGold += 1f;
        }
    }
}
