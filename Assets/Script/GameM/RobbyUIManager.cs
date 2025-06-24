using TMPro;
using UnityEngine;

public class RobbyUIManager : MonoBehaviour
{
    public static RobbyUIManager Instance { get; private set; }


    
    public GameObject startMenu; // start��ư

    public TextMeshProUGUI blueText;
    public TextMeshProUGUI redText;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // �ʿ��ϸ� DontDestroyOnLoad(gameObject); �߰�
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
