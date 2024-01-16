using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScoreBoardBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _topScore;
    [SerializeField] private TMP_Text _overallScore;
    [SerializeField] private TMP_Text _spaceScore;
    [SerializeField] private TMP_Text _jungleScore;
    [SerializeField] private TMP_Text _oceanScore;
    [SerializeField] private TMP_Text _topPlayerName;
    [SerializeField] private TMP_Text _currentPlayerName;

    private int _overallScoreTotal;
    private int _spaceScoreTotal;
    private int _jungleScoreTotal;
    private int _oceanScoreTotal;
    private int _topScoreTotal;

    private void Awake()
    {
        _spaceScore.text = PlayerPrefs.GetString("SpaceScore");
        _jungleScore.text = PlayerPrefs.GetString("JungleScore");
        _oceanScore.text = PlayerPrefs.GetString("OceanScore");
        _topPlayerName.text = PlayerPrefs.GetString("TopScore");
        _currentPlayerName.text = PlayerPrefs.GetString("UserName");

        PlayerPrefs.SetString("SpaceScore", _spaceScore.text);
        PlayerPrefs.SetString("JungleScore", _jungleScore.text);
        PlayerPrefs.SetString("OceanScore", _oceanScore.text);
        PlayerPrefs.SetString("TopScore", _topPlayerName.text);
        PlayerPrefs.Save();


    }

    private void Update()
    {
        TopScore();
    }
    public void SpaceScore(int score)
    {
        _spaceScore.text = score.ToString();
        PlayerPrefs.SetString("SpaceScore", _spaceScore.text);
        PlayerPrefs.SetInt("SpaceScore", score);
        PlayerPrefs.Save();
    }

    public void JungleScore(int score)
    {
        _jungleScore.text = score.ToString();
        PlayerPrefs.SetString("JungleScore", _jungleScore.text);
        PlayerPrefs.SetInt("JungleScore", score);
        PlayerPrefs.Save();

    }

    public void OceanScore(int score)
    {
        _oceanScore.text = score.ToString();
        PlayerPrefs.SetString("OceanScore", _oceanScore.text);
        PlayerPrefs.SetInt("OceanScore", score);
        PlayerPrefs.Save();

    }

    public void OverallScore()
    {
        _spaceScoreTotal = PlayerPrefs.GetInt("SpaceScore", 0);

        _jungleScoreTotal = PlayerPrefs.GetInt("JungleScore", 0);

        _oceanScoreTotal = PlayerPrefs.GetInt("OceanScore", 0);

        _overallScore.text = (_spaceScoreTotal + _jungleScoreTotal + _oceanScoreTotal).ToString();
    }

    public void TopScore()
    {
        // if Overall score is greater than the top score
        //Update Top Score
        //PlayerPrefs.SetString("TopScore", score);
        _topScore.text = _topScoreTotal.ToString();

        if (_overallScoreTotal > _topScoreTotal)
        {
            _topScoreTotal = _overallScoreTotal;
            PlayerPrefs.SetString("TopScore", _topScore.text);
            PlayerPrefs.SetInt("TopScore", _topScoreTotal);
            _currentPlayerName = _topPlayerName;
            PlayerPrefs.Save();
        }
    }

    public void ResetScores()
    {
        PlayerPrefs.SetString("SpaceScore", "00");
        PlayerPrefs.SetString("JungleScore", "00");
        PlayerPrefs.SetString("OceanScore", "00");
        PlayerPrefs.SetString("Username", "");
    }
}
