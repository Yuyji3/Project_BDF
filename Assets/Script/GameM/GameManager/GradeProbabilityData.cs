using UnityEngine;

[CreateAssetMenu(fileName = "GradeProbabilityData", menuName = "Scriptable Objects/GradeProbability")]
public class GradeProbabilityData : ScriptableObject
{
    public float probF = 40f;
    public float probD = 20f;
    public float probC = 15f;
    public float probB = 10f;
    public float probA = 7f;
    public float probS = 5f;
    public float probSS = 2f;
    public float probSSS = 1f;
}
