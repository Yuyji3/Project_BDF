using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentGold = 1000000f;
    public float currentBlue = 1000f;
    public float currentRed =  1000f;

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

}
