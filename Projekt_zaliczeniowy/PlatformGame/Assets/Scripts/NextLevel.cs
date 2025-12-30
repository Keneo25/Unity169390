using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [Header("Konfiguracja Poziomu")]
    [SerializeField] private string nextLevelName;
    [SerializeField] private int levelIndex;
    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("LevelReached", levelIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1;

    }
    
}
