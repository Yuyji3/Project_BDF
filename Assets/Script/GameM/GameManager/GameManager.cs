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

}
