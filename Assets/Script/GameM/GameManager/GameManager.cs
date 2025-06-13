using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentGold = 1000f;

    public TextMeshProUGUI goldText;

    public static GameManager Instance { get; private set; }

    void Update()
    {
        goldText.text = $"{currentGold}";
    }
    

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

}
