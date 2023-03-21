using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    private AudioManager audiomanager;

    [Header("Volume Settings")]
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private TextMeshProUGUI mainVolume;
    [SerializeField] private Slider mainVolumeSlider;

    [Header("Graphics Settings")]
    private bool isFullscreen;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] Toggle fullscreenToggle;

    [Header("Resolutions Dropdown")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        audiomanager = FindObjectOfType<AudioManager>();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        PlayerPrefs.SetInt("resolutionDropdownIndex", currentResolutionIndex);
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        loadAllSettings();
    }

    public void playSfx()
    {
        audiomanager.play("ui");
    }

    public void loadGameScene(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        StartCoroutine(SceneTransition(sceneName));
    }
    public IEnumerator SceneTransition(string sceneName)
    {
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("fadeToBlack");
        audiomanager.play("impact");
        FindObjectOfType<Camera>().GetComponent<Animator>().SetTrigger("fadeToBlack");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    //------------------------------------------------AUDIO SETTINGS----------------------------------------------

    public void setMainVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("masterVolume", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("masterVolumeSliderValue", sliderValue);
        PlayerPrefs.SetString("masterVolumeText", Mathf.FloorToInt(sliderValue * 100) + "%");

        mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("masterVolume"));
        mainVolume.text = PlayerPrefs.GetString("masterVolumeText");
    }

    //------------------------------------------------GRAPHICS SETTINGS----------------------------------------------

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

    public void setQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("quality", qualityIndex);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionWidth", resolution.width);
        PlayerPrefs.SetInt("resolutionHeight", resolution.height);
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

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 3));
        qualityDropdown.value = PlayerPrefs.GetInt("quality", 3);

        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionDropdownIndex");




        Screen.SetResolution(PlayerPrefs.GetInt("resolutionWidth"), PlayerPrefs.GetInt("resolutionHeight"), isFullscreen);
    }
}


