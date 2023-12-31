using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SideMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _sideMenu;
    [SerializeField] private GameObject _gameSelectMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _scoreBoard;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _brightnessSlider;
    [SerializeField] private Image _blackOverlay;
    [SerializeField] public TextMeshProUGUI _nameHolder;
    private bool _menuIsActive = false;

    private void Awake()
    {
        PlayerNameOutput();
        AudioPreference();
        BrightnessPreference();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffMenu();
            CloseGameSelect();
            CloseSettings();
        }
    }
    public void TurnOffMenu()
    {
        _menuIsActive = !_menuIsActive;

        if (_menuIsActive == true)
        {
            Time.timeScale = 0;
            SwitchMenu();
        }

        if (_menuIsActive == false)
        {
            Time.timeScale = 1;
            SwitchMenu();
            _gameSelectMenu.SetActive(false);
        }
    }
    public void SwitchMenu()
    {
        if (_menuIsActive == true)
        {
            _sideMenu.SetActive(true);
        }

        if (_menuIsActive == false)
        {
            _sideMenu.SetActive(false);
        }
    }

    public void Attributes()
    {
        Application.OpenURL("https://docs.google.com/document/d/19XEy7IuvIJIZ0OIWVZlIbp6GJ_ip-tRRYEQk1rrF8Js/edit?usp=sharing");
    }

    public void SelectGame()
    {
        _gameSelectMenu.SetActive(true);
    }

    public void CloseGameSelect()
    {
        _gameSelectMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        _settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsMenu.SetActive(false);
        PlayerPrefs.Save();
    }

    public void AudioLevels()
    {
        _audioMixer.SetFloat("Master", _audioSlider.value);
        PlayerPrefs.SetFloat("AudioSet", _audioSlider.value);
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
    }

    private void BrightnessPreference()
    {
        _brightnessSlider.value = PlayerPrefs.GetFloat("BrightnessSet");
    }

    public void PlayerNameOutput()
    {
        _nameHolder.text = PlayerPrefs.GetString("UserName");
    }

    public void ScoreBoard()
    {
        _scoreBoard.SetActive(true);
    }

    public void CloseScoreBoard()
    {
        _scoreBoard.SetActive(false);
    }
}
