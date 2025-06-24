using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentGold = 1000000f;

    public static GameManager Instance { get; private set; }


    public TextMeshProUGUI blueText;
    public TextMeshProUGUI redText;

    private void Awake()
    {
        // 하나만 존재하도록 보장
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지하고 싶을 경우
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
    void Start()
    {
        CashReflash();
    }
    public void CashReflash()
    {

        blueText.text = $"{SaveManager.Instance.Data.blueCrystal}";
        redText.text = $"{SaveManager.Instance.Data.redCrystal}";
    }
}
