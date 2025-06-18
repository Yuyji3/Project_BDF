using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillnumber; // �迭 ��ȣ
    public string skillname;
    public Sprite icon;

    public int level; // ���� ����
    public int currentpower; //���� ��ġ
    public int uppower; // �������� ��ġ

    [TextArea(2, 5)]
    public string skillex; // ��ų ����

    // ��ų �ڵ� Ȯ�ο�
    public GameObject skillPrefab;

    public string skillScriptTypeName;
}
