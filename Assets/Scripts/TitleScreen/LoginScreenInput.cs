using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LoginScreenInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerTitle;
    [SerializeField] private TextMeshProUGUI _PlayerTitleShade;
    [SerializeField] private TextMeshProUGUI _textInstructions;
    [SerializeField] private TextMeshProUGUI _textInstructionsShade;
    [SerializeField] private TMP_InputField _userInput;
    [SerializeField] private Button _loginButton;
    [SerializeField] private GameObject _enterButton;
    [SerializeField] private GameObject _selectGameButton;
    [SerializeField] private TextMeshProUGUI _selectButtonText;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private string _playerName;
    [SerializeField] private GameObject _selectGame;

    private void Start()
    {
        _textInstructions.text = "Please enter your Player name";
        _textInstructionsShade.text = "Please enter your Player name";
    }

    public void CreatePlayerName()
    {
        if (_userInput.text.Length > 2 && _userInput.text.Length < 11)
        {
            _playerName = _userInput.text;
            _textInstructions.text = "Thanks " + _userInput.text + "!!";
            _textInstructionsShade.text = "Thanks " + _userInput.text + "!!";
            _selectButtonText.text = "Play!";
            _enterButton.SetActive(false);
            _selectGameButton.SetActive(true);
        }
        else
        {
            _textInstructions.text = "Sorry, the Player Name must be between 3 and 10 characters...";
            _textInstructionsShade.text = "Sorry, the Player Name must be between 3 and 10 characters...";
            _userInput.text = "";
        }
    }

    public void EnableSelectGame()
    {
        _selectGame.SetActive(true);
        _playerTitle.text = "Select A Game";
        _PlayerTitleShade.text = "Select A Game";
    }
}
