using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{

    
    public void OnClikButtonCampaign(string Campaign)
    {
        SceneManager.LoadScene(Campaign);
        Time.timeScale = 1f;

    }
    public void OnClikButtonRobby(string Robby)
    {
        SceneManager.LoadScene(Robby);
        Time.timeScale = 1f;
        GameManager.Instance.CashReflash();
    }


}
