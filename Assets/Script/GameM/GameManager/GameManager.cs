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
        // �ϳ��� �����ϵ��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� �Ѿ�� �����ϰ� ���� ���
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
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
