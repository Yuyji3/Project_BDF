using UnityEditor;
using UnityEngine;

public class CoinSC : MonoBehaviour
{

    private float rotate=180f;

    private GameObject coinObject;

    [SerializeField]
    private float gradeSSS;
    [SerializeField]
    private float gradeSS;
    [SerializeField]
    private float gradeS;
    [SerializeField]
    private float gradeA;
    [SerializeField]
    private float gradeB;
    void Update()
    {

        if (coinObject != null)
        {
            coinObject.transform.Rotate(0, rotate * Time.deltaTime, 0);
        }

    }
    void Start()
    {

        GameObject _coinPrefeb = Resources.Load<GameObject>("Skills_Icon/Coin");

        coinObject = Instantiate(_coinPrefeb);
        coinObject.transform.position = new Vector3(transform.position.x,transform.position.y+0.4f,0);
    }
}
