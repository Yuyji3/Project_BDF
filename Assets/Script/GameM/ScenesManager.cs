using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private GameObject weaponSelectUI;

    
    public void OnClikButtonCampaign(string Campaign)
    {
        SceneManager.LoadScene(Campaign);
    }
    public void OnClickButtonStart()
    {
        startMenu.SetActive(true);
    }

    public void OnClickButtonSelect()
    {
        //weaponSelectUI.SetActive(false);
        Destroy(weaponSelectUI);
    }
}
