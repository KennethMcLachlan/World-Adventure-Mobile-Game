using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMechanics : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipeArray;
    private int _activePipeID;
    private bool[] _isPipeLocked;

    [SerializeField] private GameObject _roundOne;
    [SerializeField] private GameObject _roundTwo;
    [SerializeField] private GameObject _roundThree;
    [SerializeField] private GameObject _stars;
    [SerializeField] private GameObject _pipeGroup01;
    [SerializeField] private GameObject _pipeGroup02;
    [SerializeField] private GameObject _pipeGroup03;
    [SerializeField] private GameObject _gameOverScreen;

    public GameTimer _gameTimer;

    private bool _lockPipe0;
    private bool _lockPipe1;
    private bool _lockPipe2;
    private bool _lockPipe3;
    private bool _lockPipe4;
    private bool _lockPipe5;
    private bool _lockPipe6;
    private bool _lockPipe7;
    private bool _lockPipe8;
    private bool _lockPipe9;
    private bool _lockPipe10;
    private bool _lockPipe11;

    [SerializeField] private AudioSource _successSFX;
    [SerializeField] private Animator _textBox;

    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;

    [SerializeField] private TextMeshProUGUI _instructionText;
    [SerializeField] private TextMeshProUGUI _gameOverInstructions;
    [SerializeField] private TextMeshProUGUI _gameOverInstructionsBG;

    private float _fiveSeconds = 5f;
    private float _threeSeconds = 3f;

    void Start()
    {
        _isPipeLocked = new bool[_pipeArray.Length];
        _gameTimer = GameObject.Find("TimerManager").GetComponent<GameTimer>();
        _textBox = GameObject.Find("Image_TextBox").GetComponent<Animator>();
        _successSFX = gameObject.GetComponent<AudioSource>();
        StartCoroutine(IntroRoutine());
    }

    public void AssignPipe(int id)
    {
        _activePipeID = id;
    }

    public void RotateCurrentPipe(int direction)
    {
        if (!_isPipeLocked[_activePipeID])
        {
            _pipeArray[_activePipeID].transform.Rotate(0, 0, -15 * direction);

            SetRotationAxis();
        }
    }

    private void SetRotationAxis()
    {
        Vector3 rotation = _pipeArray[_activePipeID].GetComponent<RectTransform>().rotation.eulerAngles;

        if (rotation.z <= 1f)
        {
            _pipeArray[_activePipeID].GetComponent<Button>().enabled = false;
            _isPipeLocked[_activePipeID] = true;
            _successSFX.Play();
        }
        
        if (_activePipeID == 0 && rotation.z < 1f)
        {
            _lockPipe0 = true;
        }

        if (_activePipeID == 1 && rotation.z < 1f)
        {
            _lockPipe1 = true;
        }

        if (_activePipeID == 2 && rotation.z < 1f)
        {
            _lockPipe2 = true;
        }

        if (_activePipeID == 3 && rotation.z < 1f)
        {
            _lockPipe3 = true;
        }

        if (_activePipeID == 4 && rotation.z < 1f)
        {
            _lockPipe4 = true;
        }

        if (_activePipeID == 5 && rotation.z < 1f)
        {
            _lockPipe5 = true;
        }

        if (_activePipeID == 6 && rotation.z < 1f)
        {
            _lockPipe6 = true;
        }

        if (_activePipeID == 7 && rotation.z < 1f)
        {
            _lockPipe7 = true;
        }

        if (_activePipeID == 8 && rotation.z < 1f)
        {
            _lockPipe8 = true;
        }

        if (_activePipeID == 9 && rotation.z < 1f)
        {
            _lockPipe9 = true;
        }

        if (_activePipeID == 10 && rotation.z < 1f)
        {
            _lockPipe10 = true;
        }

        if (_activePipeID == 11 && rotation.z < 1f)
        {
            _lockPipe11 = true;
        }

        if (_lockPipe0 == true && _lockPipe1 == true && _lockPipe2 == true)
        {
            //Enable Round 2
            _gameTimer.EndRound();
            StartCoroutine(StarsRoutine());
            _lockPipe0 = false;
            _lockPipe1 = false;
            _lockPipe2 = false;
            StartCoroutine(RoundTwoRoutine());
        }

        if (_lockPipe3 == true && _lockPipe4 == true && _lockPipe5 == true && _lockPipe6 == true)
        {
            //Enable round 3
            _gameTimer.EndRound();
            StartCoroutine(StarsRoutine());
            _lockPipe3 = false;
            _lockPipe4 = false;
            _lockPipe5 = false;
            _lockPipe6 = false;
            StartCoroutine(RoundThreeRoutine());
        }

        if (_lockPipe7 == true && _lockPipe8 == true && _lockPipe9 == true && _lockPipe10 == true && _lockPipe11 == true)
        {
            //End Game
            _gameTimer.EndRound();
            StartCoroutine(StarsRoutine());
            _lockPipe7 = false;
            _lockPipe8 = false;
            _lockPipe9 = false;
            _lockPipe10 = false;
            _lockPipe11 = false;
            StartCoroutine(EndSpaceGameRoutine());
        }
    }

    IEnumerator StarsRoutine()
    {
        _stars.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        _stars.SetActive(false);
    }

    IEnumerator IntroRoutine()
    {
        _textBox.SetBool("BoxIsActive", true);
        _instructionText.text = "We're moving to the moon and we need your help!";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Our hyper drive is broken and only you can fix it.";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "The drive pipes fell apart. reconnect them before they explode!";

        yield return new WaitForSeconds(_fiveSeconds);
        _roundOne.SetActive(true);
        _textBox.SetBool("BoxIsActive", false);
        _stars.SetActive(true);

        yield return new WaitForSeconds(_threeSeconds);
        _roundOne.SetActive(false);
        _pipeGroup01.SetActive(true);
        ResetRoundTimer();

        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);
    }

    IEnumerator RoundTwoRoutine()
    {
        yield return new WaitForSeconds(_threeSeconds);
        _pipeGroup01.SetActive(false);
        _textBox.SetBool("BoxIsActive", true);
        _instructionText.text = "Great Job!";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Ready for another round?";

        yield return new WaitForSeconds(_fiveSeconds);
        _roundTwo.SetActive(true);
        _textBox.SetBool("BoxIsActive", false);
        _stars.SetActive(true);
        _instructionText.text = "The drive pipes fell apart. reconnect them before they explode!";

        yield return new WaitForSeconds(_threeSeconds);
        _roundTwo.SetActive(false);
        _pipeGroup02.SetActive(true);
        ResetRoundTimer();

        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);
    }

    IEnumerator RoundThreeRoutine()
    {
        yield return new WaitForSeconds(_threeSeconds);
        _pipeGroup02.SetActive(false);
        _textBox.SetBool("BoxIsActive", true);
        _instructionText.text = "Great Job!";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Ready for another round?";

        yield return new WaitForSeconds(_fiveSeconds);
        _roundThree.SetActive(true);
        _textBox.SetBool("BoxIsActive", false);
        _stars.SetActive(true);
        _instructionText.text = "The drive pipes fell apart. reconnect them before they explode!";

        yield return new WaitForSeconds(_threeSeconds);
        _roundThree.SetActive(false);
        _pipeGroup03.SetActive(true);
        ResetRoundTimer();

        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);
    }

    IEnumerator EndSpaceGameRoutine()
    {
        //END GAME
        yield return new WaitForSeconds(_threeSeconds);
        _pipeGroup03.SetActive(false);
        _textBox.SetBool("BoxIsActive", true);
        _instructionText.text = "Great Job!";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "You have saved us!";

        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Our family can start new lives on the moon! Thank you!";

        yield return new WaitForSeconds(_threeSeconds);
        _gameOverScreen.SetActive(true);
        _gameOverInstructions.text = "Great Job! You saved the day!";
        _gameOverInstructionsBG.text = "Great Job! You saved the day!";
    }

    private void ResetRoundTimer()
    {
        _gameTimer.ResetTimer();
        _gameTimer.SetRound();
    }
}
