using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [Header("Panele Menu")]
    [SerializeField] private GameObject startMainMenu;
    [SerializeField] private GameObject levelMenu;
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    
    public void OpenLevelMenu()
    {
        startMainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
