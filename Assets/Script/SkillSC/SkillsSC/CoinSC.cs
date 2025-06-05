using UnityEditor;
using UnityEngine;

public class CoinSC : MonoBehaviour
{

    private float rotate=180f;

    private GameObject _coinObject;
    

    void Update()
    {

        if (_coinObject != null)
        {
            _coinObject.transform.Rotate(0, rotate * Time.deltaTime, 0);
        }

    }
    void Start()
    {

        GameObject _coinPrefeb = Resources.Load<GameObject>("Skills_Icon/Coin");

        _coinObject = Instantiate(_coinPrefeb);
        _coinObject.transform.position = new Vector3(transform.position.x,transform.position.y+0.2f,0);
    }
}
