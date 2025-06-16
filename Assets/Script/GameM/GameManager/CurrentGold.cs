using TMPro;
using UnityEngine;

public class CurrentGold : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI goldText;
    void Start()
    {
        gameManager = GameManager.Instance;


    }

    void Update()
    {
        goldText.text = $"{gameManager.currentGold}";
    }


}
