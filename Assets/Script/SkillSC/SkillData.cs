using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public float skillOdd;
    public string skillName;
    public Sprite icon;
    public int amount;


    public GameObject skillPrefab;
}
