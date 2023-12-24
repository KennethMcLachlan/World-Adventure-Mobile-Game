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

    private bool _gameIsActive;
    private bool _roundOneActive;
    private bool _roundTwoActive;
    private bool _roundThreeActive;


    [SerializeField] private AudioSource _successSFX;

    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;

    [SerializeField] private TextMeshProUGUI _instructionText;
    private float _fiveSeconds = 5f;
    private float _threeSeconds = 3f;

    void Start()
    {
        _isPipeLocked = new bool[_pipeArray.Length];
        _successSFX = gameObject.GetComponent<AudioSource>();
        StartCoroutine(IntroRoutine());
    }

    void Update()
    {
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
        
        if (_activePipeID ==  2 && rotation.z < 1f)
        {
            //Enable Round 2
            StartCoroutine(StarsRoutine());
            StartCoroutine(RoundTwoRoutine());

            Debug.Log("Round 2 can start");
        }

        if (_activePipeID == 6 && rotation.z < 1f)
        {
            //Enable round 3
            StartCoroutine(RoundThreeRoutine());
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
        _instructionText.text = "We're moving to the moon and we need your help!";
        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Our hyper drive is broken and only you can fix it.";
        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "The drive pipes fell apart, reconnect them before they explode!";
        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "";
        _roundOne.SetActive(true);
        _stars.SetActive(true);
        yield return new WaitForSeconds(_threeSeconds);
        _roundOne.SetActive(false);
        _pipeGroup01.SetActive(true);
        _gameIsActive = true;
        _roundOneActive = true;
        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);
    }

    IEnumerator RoundTwoRoutine()
    {
        yield return new WaitForSeconds(_threeSeconds);
        _pipeGroup01.SetActive(false);
        _instructionText.text = "Great Job!";
        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Ready for another round?";
        yield return new WaitForSeconds(_fiveSeconds);
        _roundTwo.SetActive(true);
        _stars.SetActive(true);
        _instructionText.text = "The drive pipes fell apart, reconnect the before they explode!";
        yield return new WaitForSeconds(_threeSeconds);
        _roundTwo.SetActive(false);
        _pipeGroup02.SetActive(true);
        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);

    }

    IEnumerator RoundThreeRoutine()
    {
        yield return new WaitForSeconds(_threeSeconds);
        _pipeGroup02.SetActive(false);
        _instructionText.text = "Great Job!";
        yield return new WaitForSeconds(_fiveSeconds);
        _instructionText.text = "Ready for another round?";
        yield return new WaitForSeconds(_fiveSeconds);
        _roundThree.SetActive(true);
        _stars.SetActive(true);
        _instructionText.text = "The drive pipes fell apart, reconnect the before they explode!";
        yield return new WaitForSeconds(_threeSeconds);
        _roundThree.SetActive(false);
        _pipeGroup03.SetActive(true);
        yield return new WaitForSeconds(2f);
        _stars.SetActive(false);
        _gameIsActive = false;
    }

}
