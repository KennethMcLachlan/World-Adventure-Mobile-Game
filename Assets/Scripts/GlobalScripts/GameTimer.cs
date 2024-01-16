using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _remainingTime;
    [SerializeField] private float _maxTime;
    private float _redBar;
    [SerializeField] private Slider _sliderTimer;
    [SerializeField] private Image _fillColor;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _gameOverInstructions;
    [SerializeField] private TextMeshProUGUI _gameOverInstructionsBG;

    [SerializeField] private int _scoreRound1;
    [SerializeField] private int _scoreRound2;
    [SerializeField] private int _scoreRound3;
    [SerializeField] private int _finalScore;

    private bool _roundIsActive;


    private void Start()
    {
        _redBar = _maxTime / 3.33f;
    }
    private void Update()
    {
        if (_roundIsActive == true)
        {
            TimerFunction();
        }
    }

    public void TimerFunction()
    {
        _remainingTime -= Time.deltaTime;

        _sliderTimer.value = _remainingTime;

        if (_remainingTime <= 0)
        {
            //End Game
            Time.timeScale = 0f;
            _gameOverScreen.SetActive(true);
            _gameOverInstructions.text = "Ran out of time!";
            _gameOverInstructionsBG.text = _gameOverInstructions.text;
            Debug.Log("Timer has reached zero");
        }

        if (_sliderTimer.value <= _redBar)
        {
            _fillColor.GetComponent<Image>().color = Color.red;
        }

    }

    public void ResetTimer()
    {
        _remainingTime = _maxTime;
    }

    public void SetRound()
    {
        _roundIsActive = true;
    }

    public void EndRound()
    {
        _roundIsActive = false;
    }

    public int TimerPoints()
    {
        float points = 0;
        points = _sliderTimer.value;
        int score = Mathf.CeilToInt (points * 5f);
        return score;
    }
}
