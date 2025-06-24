using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float currentGold = 1000000f;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // �ϳ��� �����ϵ��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� �Ѿ�� �����ϰ� ���� ���
                                           
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        CashReflash(); // ó�� ������ ���� ����
    }

    // ���� ������ �ε�� �� �ڵ� ȣ��
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
