using TMPro;
using UnityEngine;

public class MonsterCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    

    void Update()
    {
        counterText.text = $"{MonsterManager.GetCount()} / {MonsterManager.maxCount}";
    }
}