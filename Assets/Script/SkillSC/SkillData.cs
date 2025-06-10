using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillOdd;
    public string skillName;
    public Sprite icon;
    public int amount;

    // ��ų �ڵ� Ȯ�ο�
    public GameObject skillPrefab;

    public string skillScriptTypeName;
}
