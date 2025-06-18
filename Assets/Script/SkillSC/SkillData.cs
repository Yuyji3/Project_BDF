using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillnumber; // �迭 ��ȣ
    public string skillname;
    public Sprite icon;
    public int level; // ��ȭ ��ġ

    // ��ų �ڵ� Ȯ�ο�
    public GameObject skillPrefab;

    public string skillScriptTypeName;
}
