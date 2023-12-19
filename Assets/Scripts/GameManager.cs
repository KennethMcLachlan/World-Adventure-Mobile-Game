using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _brightnessSlider;
    [SerializeField] private Image _blackOverlay;
    [SerializeField] public TextMeshProUGUI _nameHolder;

    private void Awake()
    {
        PlayerNameOutput();
        AudioPreference();
        BrightnessPreference();
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SpaceScene()
    {
        SceneManager.LoadScene("SpaceLevel");
    }

    public void JungleScene()
    {
        SceneManager.LoadScene("JungleLevel");
    }

    public void OceanScene()
    {
        SceneManager.LoadScene("OceanLevel");
    }

    public void AudioLevels()
    {
        _audioMixer.SetFloat("Master", _audioSlider.value);
        PlayerPrefs.SetFloat("AudioSet", _audioSlider.value);
        PlayerPrefs.Save();
    }

    private void AudioPreference()
    {
        PlayerPrefs.GetFloat("AudioSet");
    }
    public void BrightnessLevels()
    {
        var tempColor = _blackOverlay.color;
        tempColor.a = _brightnessSlider.value;
        _blackOverlay.color = tempColor;

        PlayerPrefs.SetFloat("BrightnessSet", _brightnessSlider.value);
        PlayerPrefs.Save();
    }

    private void BrightnessPreference()
    {
        PlayerPrefs.GetFloat("BrightnessSet");
    }

    public void PlayerNameOutput()
    {
        _nameHolder.text = PlayerPrefs.GetString("UserName");
    }
}
