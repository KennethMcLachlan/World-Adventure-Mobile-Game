using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JungleMechanics : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _monkeyText01;
    [SerializeField] private TextMeshProUGUI _monkeyTextBG01;
    [SerializeField] private TextMeshProUGUI _monkeyText02;
    [SerializeField] private TextMeshProUGUI _monkeyTextBG02;
    [SerializeField] private TextMeshProUGUI _textInstructions;
    [SerializeField] private TextMeshProUGUI _gameOverInstructions;
    [SerializeField] private TextMeshProUGUI _gameOverInstructionsBG;

    [SerializeField] private GameObject _stars;
    [SerializeField] private GameObject _round01;
    [SerializeField] private GameObject _round02;
    [SerializeField] private GameObject _round03;
    [SerializeField] private GameObject _greatJob;
    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] private Transform _image04;
    [SerializeField] private Transform _image07;
    [SerializeField] private Transform _image04Container;
    [SerializeField] private Transform _image07Container;

    [SerializeField] private Animator _textBox;

    [SerializeField] private DropZone _dropZone;

    private GameTimer _gameTimer;

    private float _fiveSeconds = 5f;
    private float _threeSeconds = 3f;

    void Start()
    {
        _gameTimer = GameObject.Find("TimerManager").GetComponent<GameTimer>();
        _textBox = GameObject.Find("Image_TextBox").GetComponent<Animator>();
        _dropZone = GameObject.Find("Image_DropZone").GetComponent<DropZone>();

        if (_dropZone == null)
        {
            Debug.Log("DropZone is null");
        }

        StartCoroutine(IntroRoutine());
    }

    IEnumerator IntroRoutine()
    {
        _monkeyText01.text = "";
        _monkeyTextBG01.text = _monkeyText01.text;
        _monkeyText02.text = "";
        _monkeyTextBG02.text = _monkeyText02.text;
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Welcome!";
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "We want to be Astronauts some day!";
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "Astronauts need to be great at math.";
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "Let's practice some math!";
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "Math is fun!";
        _textBox.SetBool("BoxIsActive", false);
        _stars.SetActive(true);
        _round01.SetActive(true);
        yield return new WaitForSeconds(_threeSeconds);

        _dropZone.SetRoundOne();
        _round01.SetActive(false);
        _stars.SetActive(false);

        _monkeyText01.text = "2";
        _monkeyTextBG01.text = _monkeyText01.text;
        _monkeyText02.text = "2";
        _monkeyTextBG02.text = _monkeyText02.text;

        ResetRoundTimer();
    }

    IEnumerator RoundTwoRoutine()
    {
        _gameTimer.EndRound();
        _dropZone.EndRoundOne();
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Great Job!";
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "Ready for round 2?";
        _image04.position = _image04Container.transform.position;
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(true);
        _textInstructions.text = "Math is fun!";
        _round02.SetActive(true);
        yield return new WaitForSeconds(_threeSeconds);

        _stars.SetActive(false);
        _dropZone.SetRoundTwo();
        _round02.SetActive(false);
        _textBox.SetBool("BoxIsActive", false);

        _monkeyText01.text = "4";
        _monkeyTextBG01.text = _monkeyText01.text;
        _monkeyText02.text = "3";
        _monkeyTextBG02.text = _monkeyText02.text;

        ResetRoundTimer();
    }

    IEnumerator RoundThreeRoutine()
    {
        _gameTimer.EndRound();
        _dropZone.EndRoundTwo();
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Great Job!";
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "Ready for round 3?";
        _image07.position = _image07Container.transform.position;
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(true);
        _textInstructions.text = "Math is fun!";
        _round03.SetActive(true);
        yield return new WaitForSeconds(_threeSeconds);

        _stars.SetActive(false);
        _dropZone.SetRoundThree();
        _round03.SetActive(false);
        _textBox.SetBool("BoxIsActive", false);

        _monkeyText01.text = "4";
        _monkeyTextBG01.text = _monkeyText01.text;
        _monkeyText02.text = "5";
        _monkeyTextBG02.text = _monkeyText02.text;

        ResetRoundTimer();
    }

    IEnumerator GameCompleteRoutine()
    {
        _gameTimer.EndRound();
        _dropZone.EndRoundThree();
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Great Job!";
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "You solved all of the problems!";
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "One day we will go to space!";
        yield return new WaitForSeconds(_threeSeconds);

        _gameOverScreen.SetActive(true);
        _gameOverInstructions.text = "Math is fun!";
        _gameOverInstructionsBG.text = _gameOverInstructions.text;

    }

    public void RoundOneComplete()
    {
        StartCoroutine(RoundTwoRoutine());
    }

    public void RoundTwoComplete()
    {
        StartCoroutine(RoundThreeRoutine());
    }

    public void RoundThreeComplete()
    {
        StartCoroutine(GameCompleteRoutine());
    }

    private void ResetRoundTimer()
    {
        _gameTimer.ResetTimer();
        _gameTimer.SetRound();
    }
}
