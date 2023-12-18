using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePosition : MonoBehaviour
{
    [SerializeField] private RectTransform _title;
    [SerializeField] private RectTransform _movePoint;

    public void MoveTitle()
    {
        _title.transform.position = _movePoint.position;
    }
}
