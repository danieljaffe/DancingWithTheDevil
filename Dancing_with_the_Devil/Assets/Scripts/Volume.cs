using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            LoadVolume();
        }
        
        else
        {
            LoadVolume();    
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }
    
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
    }
}
