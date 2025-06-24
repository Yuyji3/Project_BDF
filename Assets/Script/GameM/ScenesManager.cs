using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{

    
    public void OnClikButtonCampaign(string Campaign)
    {
        SceneManager.LoadScene(Campaign);

        
    }
    public void OnClikButtonRobby(string Robby)
    {
        SceneManager.LoadScene(Robby);

        GameManager.Instance.CashReflash();
    }
    public void OnClickButtonStart()
    {


        RobbyUIManager.Instance.startMenu.SetActive(true);
    }

}
