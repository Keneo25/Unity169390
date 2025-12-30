using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Ustawienia")]
    [SerializeField] private TextMeshProUGUI timerText; 

    private float _timeElapsed;

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        
        double minutes = Mathf.Floor(_timeElapsed / 60);
        double seconds = _timeElapsed % 60;
        
        if (timerText)
        {
            timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
        }
    }
}