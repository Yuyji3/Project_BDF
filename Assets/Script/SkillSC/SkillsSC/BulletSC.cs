using UnityEngine;

public class BulletSC : MonoBehaviour
{
    private int currentint3;
    public Button buttonManager;

    public SkillGrade grade;

    void Start()
    {
        GameObject targetObj = GameObject.Find("ButtonManager");
        if (targetObj != null)
        {
            buttonManager = targetObj.GetComponent<Button>();
        }

        currentint3 = buttonManager.currentInt3;

    }

    void Update()
    {
        Skillset();
    }
    public void Skillset()
    {

        if (buttonManager.slots[currentint3].grade == SkillGrade.SSS)
        {

            Tower.Instance.attackPower = 0.44f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.SS)
        {

            Tower.Instance.attackPower = 0.46f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.S)
        {
 
            Tower.Instance.attackPower = 0.48f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.A)
        {

            Tower.Instance.attackPower = 0.50f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.B)
        {

            Tower.Instance.attackPower = 0.52f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.C)
        {
  
            Tower.Instance.attackPower = 0.54f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.D)
        {
  
            Tower.Instance.attackPower = 0.56f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.E)
        {
 
            Tower.Instance.attackPower = 0.58f;
            Tower.Instance.fireRate = 0.5f;
        }
        if (buttonManager.slots[currentint3].grade == SkillGrade.F)
        {

            Tower.Instance.attackPower = 0.6f;
            Tower.Instance.fireRate = 0.5f;
        }
    }
}
