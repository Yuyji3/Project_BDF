using UnityEditor;
using UnityEngine;

public class CoinSC : MonoBehaviour
{

    private float rotate=180f;

    private GameObject coinObject;

    public SkillGrade grade;

    
    public GameManager gameManager;

    void Update()
    {

        if (coinObject != null)
        {
            coinObject.transform.Rotate(0, rotate * Time.deltaTime, 0);
        }

        gameManager.currentGold += 1f;
    }
    void Start()
    {

        gameManager = GameManager.Instance;

        Debug.Log($"코인 등급: {grade}");

        GameObject _coinPrefeb = Resources.Load<GameObject>("Skills_Icon/Coin");

        coinObject = Instantiate(_coinPrefeb);
        coinObject.transform.position = new Vector3(transform.position.x,transform.position.y+0.4f,0);

        
    }
    public void Cleanup()
    {
        if (coinObject != null)
        {
            Destroy(coinObject);
        }
    }
}
