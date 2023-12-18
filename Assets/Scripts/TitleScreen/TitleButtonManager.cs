using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _loginScreen;

    public void StartButton()
    {
        _loginScreen.SetActive(true);
    }

}
