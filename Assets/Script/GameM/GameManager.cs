using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponSelectUI;
    void Start()
    {
        weaponSelectUI.SetActive(true);
    }
    public enum SkillGrade
    {
        F, D, C, B, A, S, SS, SSS
    }

}
