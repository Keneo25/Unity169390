using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private Slider _mySlider;

    void Start()
    {
        _mySlider = GetComponent<Slider>();
        _mySlider.value = AudioListener.volume;
        _mySlider.onValueChanged.AddListener(SetLevel);
    }

    private void SetLevel(float sliderValue)
    {
        AudioListener.volume = sliderValue;
    }
}