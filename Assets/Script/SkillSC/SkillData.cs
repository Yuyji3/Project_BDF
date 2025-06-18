using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillnumber; // 배열 번호
    public string skillname;
    public Sprite icon;
    public int level; // 강화 수치

    // 스킬 코드 확인용
    public GameObject skillPrefab;

    public string skillScriptTypeName;
}
