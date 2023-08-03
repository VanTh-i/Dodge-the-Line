using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BgSlider, SFXSlider;
    [SerializeField] private GameObject VolumeSettingUI;

    bool isActive;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGVolume();
            SetSFXVolume();
        }
    }
    public void SetBGVolume()
    {
        float volume = BgSlider.value;
        audioMixer.SetFloat("BG", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        BgSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetBGVolume();

        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }
    public void SettingBtn()
    {
        if (isActive)
        {
            VolumeSettingUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isActive = false;
        }
        else
        {
            VolumeSettingUI.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isActive = true;
        }

    }
}
