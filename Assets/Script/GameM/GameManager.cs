using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponSelectUI;
    void Start()
    {
        weaponSelectUI.SetActive(true);
    }

}
