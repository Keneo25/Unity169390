using UnityEngine;
using UnityEngine.UI;
public class LevelButton : MonoBehaviour
{
    [Header("Indeks Poziomu")]
    [SerializeField] private int levelIndex;
    void Start()
    {
        Button btn = GetComponent<Button>();
        if (PlayerPrefs.GetInt("LevelReached") < levelIndex)
        {
            btn.interactable = false;
        }
    }
}
