using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScoreBoardBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topScore;
    [SerializeField] private TextMeshProUGUI _overallScore;
    [SerializeField] private TextMeshProUGUI _spaceScore;
    [SerializeField] private TextMeshProUGUI _jungleScore;
    [SerializeField] private TextMeshProUGUI _oceanScore;

    [SerializeField] private Slider _gameTimer;
}
