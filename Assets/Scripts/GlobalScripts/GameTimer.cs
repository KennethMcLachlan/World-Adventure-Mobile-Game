using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _remainingTime;
    [SerializeField] private float _maxTime;
    private float _redBar;
    [SerializeField] private Slider _sliderTimer;
    [SerializeField] private Image _fillColor;

    private void Start()
    {
        _redBar = _maxTime / 3.33f;
    }
    private void Update()
    {
        TimerFunction();
    }

    public void TimerFunction()
    {
        _remainingTime -= Time.deltaTime;

        _sliderTimer.value = _remainingTime;

        if (_remainingTime <= 0)
        {
            //End Game
            Debug.Log("Timer has reached zero");
        }

        if (_sliderTimer.value <= _redBar)
        {
            _fillColor.GetComponent<Image>().color = Color.red;
        }

    }

}
