using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillnumber; // 배열 번호
    public string skillname;
    public Sprite icon;

    public int level; // 현제 레벨
    public int currentpower; //현재 수치
    public int uppower; // 다음레벨 수치

    [TextArea(2, 5)]
    public string skillex; // 스킬 설명

    // 스킬 코드 확인용
    public GameObject skillPrefab;

    public string skillScriptTypeName;
}
