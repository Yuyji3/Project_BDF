using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;


    
    public void OnClikButtonCampaign(string Campaign)
    {
        SceneManager.LoadScene(Campaign);
    }
    public void OnClickButtonStart()
    {
        startMenu.SetActive(true);
    }

}
