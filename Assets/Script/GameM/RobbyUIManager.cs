using TMPro;
using UnityEngine;

public class RobbyUIManager : MonoBehaviour
{
    public static RobbyUIManager Instance { get; private set; }


    
    public GameObject startMenu; // start버튼

    public TextMeshProUGUI blueText;
    public TextMeshProUGUI redText;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // 필요하면 DontDestroyOnLoad(gameObject); 추가
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
