using UnityEngine;

public class CoinSC : MonoBehaviour
{

    private float rotate=180f;
    
    void Update()
    {

        transform.Rotate(0, rotate * Time.deltaTime, 0);
    }
}
