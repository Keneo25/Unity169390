using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroller : MonoBehaviour
{
    [Header("Ustawienia Przewijania")]
    [SerializeField] private float scrollSpeed = 50f;
    [SerializeField] private float endY = 20000f;
    
    [Header("Scena Menu")]
    [SerializeField] private string menuSceneName; 
    
    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        _rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        if (_rectTransform.anchoredPosition.y > endY)
        {
            LoadMenu();
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}