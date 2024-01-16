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
        _spaceScoreTotal = PlayerPrefs.GetInt("SpaceScore");
        _jungleScoreTotal = PlayerPrefs.GetInt("JungleScore");
        _oceanScoreTotal = PlayerPrefs.GetInt("OceanScore");
        _topScoreTotal = PlayerPrefs.GetInt("TopScore");

        _currentPlayerName.text = PlayerPrefs.GetString("UserName");
        _spaceScore.text = _spaceScoreTotal.ToString();
        _jungleScore.text = _jungleScoreTotal.ToString();
        _oceanScore.text = _oceanScoreTotal.ToString();

        OverallScore();
        _overallScore.text = _overallScoreTotal.ToString();
    }

    private void Update()
    {
        TopScore();
    }
    public void SpaceScore(int score)
    {
        _spaceScore.text = score.ToString();
        _spaceScoreTotal = score;
        PlayerPrefs.SetInt("SpaceScore", score);
        PlayerPrefs.Save();
    }

    public void JungleScore(int score)
    {
        _jungleScore.text = score.ToString();
        _jungleScoreTotal = score;
        PlayerPrefs.SetInt("JungleScore", score);
        PlayerPrefs.Save();

    }

    public void OceanScore(int score)
    {
        _oceanScore.text = score.ToString();
        _oceanScoreTotal = score;
        PlayerPrefs.SetInt("OceanScore", score);
        PlayerPrefs.Save();

    }

    public void OverallScore()
    {
        _overallScoreTotal = (_spaceScoreTotal + _jungleScoreTotal + _oceanScoreTotal);
        _overallScore.text = _overallScoreTotal.ToString();
    }

    public void TopScore()
    {
        _topScore.text = _topScoreTotal.ToString();

        if (_overallScoreTotal > _topScoreTotal)
        {
            _topScoreTotal = _overallScoreTotal;
            _topScore.text = _topScoreTotal.ToString();

            PlayerPrefs.SetInt("TopScore", _topScoreTotal);
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
