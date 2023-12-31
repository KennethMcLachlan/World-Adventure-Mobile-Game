using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using TMPro;

public class OceanMechanics : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public Sprite[] puzzles;
    public Sprite BGImage;

    [SerializeField] private TextMeshProUGUI _textInstructions;
    [SerializeField] private TextMeshProUGUI _textInstructionsBG;
    [SerializeField] private TextMeshProUGUI _gameOverInstructions;
    [SerializeField] private TextMeshProUGUI _gameOverInstructionsBG;

    [SerializeField] private Animator _textBox;
    [SerializeField] private AudioSource _successSFX;

    [SerializeField] private GameObject _stars;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _startTitle;
    [SerializeField] private GameObject _greatJobTitle;

    private float _fiveSeconds = 5f;
    private float _threeSeconds = 3f;

    private GameTimer _gameTimer;

    private bool _firstGuess;
    private bool _secondGuess;

    private int _countGuesses;
    private int _countCorrectGuesses;
    private int _gameGuesses;

    private int _firstGuessIndex;
    private int _secondGuessIndex;

    private string _firstGuessPuzzle, _secondGuessPuzzle;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Ocean_MemoryGameCritters-01");
        //shellImage = Resources.LoadAll<Sprite>("Ocean_ClamShells-01");
    }
    private void Start()
    {
        _gameTimer = GameObject.Find("TimerManager").GetComponent<GameTimer>();
        if (_gameTimer == null)
        {
            Debug.Log("Timer is NULL!");
        }
        StartCoroutine(IntroRoutine());
    }

    private void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("ShellButton");

        for (int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = BGImage;
        }
    }

    private void AddGamePuzzles()
    {
        int looper = buttons.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }
    private void AddListeners()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (!_firstGuess)
        {
            _firstGuess = true;
            _firstGuessIndex = int.Parse(name);
            _firstGuessPuzzle = gamePuzzles[_firstGuessIndex].name;
            buttons[_firstGuessIndex].image.sprite = gamePuzzles[_firstGuessIndex];
        }
        else if (!_secondGuess)
        {
            _secondGuess = true;
            _secondGuessIndex = int.Parse(name);
            _secondGuessPuzzle = gamePuzzles[_secondGuessIndex].name;
            buttons[_secondGuessIndex].image.sprite = gamePuzzles[_secondGuessIndex];
            _countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(0.75f);

        if (_firstGuessPuzzle == _secondGuessPuzzle && _firstGuessIndex != _secondGuessIndex)
        {
            _successSFX.Play();
            yield return new WaitForSeconds(0.5f);

            buttons[_firstGuessIndex].interactable = false;
            buttons[_secondGuessIndex].interactable = false;

            buttons[_firstGuessIndex].image.color = new Color(0, 0, 0, 0.25f);
            buttons[_secondGuessIndex].image.color = new Color(0, 0, 0, 0.25f);

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            buttons[_firstGuessIndex].image.sprite = BGImage;
            buttons[_secondGuessIndex].image.sprite = BGImage;
        }

        yield return new WaitForSeconds(0.5f);

        _firstGuess = false;
        _secondGuess = false;
    }

    private void CheckIfTheGameIsFinished()
    {
        _countCorrectGuesses++;

        if (_countCorrectGuesses == _gameGuesses)
        {
            StartCoroutine(ExitRoutine());
            Debug.Log("Game finished");
        }
    }

    private void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    //private void ShuffleButtons(List<Sprite> list)
    //{
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        Sprite temp = list[i];
    //        int randomIndex = Random.Range(i, list.Count);
    //        list[i] = list[randomIndex];
    //        list[randomIndex] = temp;
    //    }
    //}

    IEnumerator IntroRoutine()
    {
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Welcome to the deep blue sea!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "Let's work on our memory skills!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "Match two sea critters to continue.";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "Clear the board to win!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(true);
        _successSFX.Play();
        _startTitle.SetActive(true);
        _textInstructions.text = "Ready?!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_threeSeconds);

        _startTitle.SetActive(false);
        _stars.SetActive(false);
        _textBox.SetBool("BoxIsActive", false);
        _textInstructions.text = "The ocean is magical!";
        _textInstructionsBG.text = _textInstructions.text;
        _gameTimer.ResetTimer();
        _gameTimer.SetRound();
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        _gameGuesses = gamePuzzles.Count / 2;

    }

    IEnumerator ExitRoutine()
    {
        _gameTimer.EndRound();
        _greatJobTitle.SetActive(true);
        _stars.SetActive(true);
        _textBox.SetBool("BoxIsActive", true);
        _textInstructions.text = "Great Job!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _stars.SetActive(false);
        _textInstructions.text = "You matched them all!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _textInstructions.text = "You have a great memory!";
        _textInstructionsBG.text = _textInstructions.text;
        yield return new WaitForSeconds(_fiveSeconds);

        _greatJobTitle.SetActive(false);
        _stars.SetActive(true);
        _gameOverScreen.SetActive(true);
        _textInstructions.text = "Thanks for playing!";
        _textInstructionsBG.text = _textInstructions.text;
        _gameOverInstructions.text = "You are a master of the deep blue sea!";
        _gameOverInstructionsBG.text = _gameOverInstructions.text;

    }
}
