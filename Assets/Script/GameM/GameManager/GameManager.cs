using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float currentGold = 1000000f;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // 하나만 존재하도록 보장
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지하고 싶을 경우
                                           
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        CashReflash(); // 처음 시작할 때도 갱신
    }

    // 씬이 완전히 로드된 후 자동 호출
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CashReflash();
    }
    public void CashReflash()
    {

        RobbyUIManager.Instance.blueText.text = $"{SaveManager.Instance.Data.blueCrystal}";
        RobbyUIManager.Instance.redText.text = $"{SaveManager.Instance.Data.redCrystal}";
    }
}
