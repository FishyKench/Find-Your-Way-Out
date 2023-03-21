using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeOptionsMidGame : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isPaused = false;
    [Space(15)]

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider mainVolumeSlider;
    [SerializeField] private TextMeshProUGUI mainVolume;
    [SerializeField] private Toggle fullscreenToggle;
    bool isFullscreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                pausePanel.SetActive(true);
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                FindObjectOfType<PlayerCam>().enabled = false;
                FindObjectOfType<PlayerMovementAdvanced>().enabled = false;
            }
            else if(isPaused == true)
            {
                pausePanel.SetActive(false);
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                FindObjectOfType<PlayerCam>().enabled = true;
                FindObjectOfType<PlayerMovementAdvanced>().enabled = true;
            }

        }
    }

    //-------------------settings---------------------
    public void setMainVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("masterVolume", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("masterVolumeSliderValue", sliderValue);
        PlayerPrefs.SetString("masterVolumeText", Mathf.FloorToInt(sliderValue * 100) + "%");

        mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("masterVolume"));
        mainVolume.text = PlayerPrefs.GetString("masterVolumeText");
    }
    public void setFullscreen(bool fullscreen)
    {
        if (fullscreen)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
            isFullscreen = true;
            Screen.fullScreen = isFullscreen;
        }
        else if (!fullscreen)
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            isFullscreen = false;
            Screen.fullScreen = isFullscreen;
        }

    }

    private void loadAllSettings()
    {
        mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("masterVolume", -13));
        mainVolume.text = PlayerPrefs.GetString("masterVolumeText", "50%");
        mainVolumeSlider.value = PlayerPrefs.GetFloat("masterVolumeSliderValue", .5f);

        if (PlayerPrefs.GetInt("fullscreen", 1) == 1)
        {
            isFullscreen = true;
            Screen.fullScreen = isFullscreen;
            fullscreenToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            isFullscreen = false;
            Screen.fullScreen = isFullscreen;
            fullscreenToggle.isOn = false;
        }
    }
}
