using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Text txtVolume;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("volume", 1);
        audioSource.enabled = (PlayerPrefs.GetInt("sound", 1) == 1) ? true : false;
        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
        txtVolume.text = "Volume(" + ((int)(volumeSlider.value * 100)) + "%)";
    }

}
