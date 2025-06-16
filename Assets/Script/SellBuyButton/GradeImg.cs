using UnityEngine;
using UnityEngine.UI;
public class GradeImg : MonoBehaviour
{
    [SerializeField]
    private Sprite[] gradeImg;

    [SerializeField]
    private Image gradeImageUI;

    [SerializeField]
    private Button button;

    private int currentint3;


    public void showgrade()
    {
        currentint3 = button.currentInt2;

        if (button.slots[currentint3].grade == SkillGrade.SSS)
        {
            gradeImageUI.sprite = gradeImg[0];
            Debug.Log("sss �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.SS)
        {
            gradeImageUI.sprite = gradeImg[1];
            Debug.Log("ss �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.S)
        {
            gradeImageUI.sprite = gradeImg[2];
            Debug.Log("s �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.A)
        {

            gradeImageUI.sprite = gradeImg[3];
            Debug.Log("a �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.B)
        {
            gradeImageUI.sprite = gradeImg[4];
            Debug.Log("b �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.C)
        {

            gradeImageUI.sprite = gradeImg[5];
            Debug.Log("c �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.D)
        {
            gradeImageUI.sprite = gradeImg[6];
            Debug.Log("d �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.E)
        {
            gradeImageUI.sprite = gradeImg[7];
            Debug.Log("e �̹���");
        }
        if (button.slots[currentint3].grade == SkillGrade.F)
        {
            gradeImageUI.sprite = gradeImg[8];
            Debug.Log("f �̹���");
        }
    }
}
