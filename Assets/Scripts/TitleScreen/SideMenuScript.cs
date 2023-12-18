using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _sideMenu;
    [SerializeField] private GameObject _gameSelectMenu;
    
    private bool _menuIsActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffMenu();
        }
    }
    public void TurnOffMenu()
    {
        _menuIsActive = !_menuIsActive;

        if (_menuIsActive == true)
        {
            Time.timeScale = 0;
            SwitchMenu();
        }

        if (_menuIsActive == false)
        {
            Time.timeScale = 1;
            SwitchMenu();
            _gameSelectMenu.SetActive(false);
        }
    }
    public void SwitchMenu()
    {
        if (_menuIsActive == true)
        {
            _sideMenu.SetActive(true);
        }

        if (_menuIsActive == false)
        {
            _sideMenu.SetActive(false);
        }
    }

    public void Attributes()
    {
        Application.OpenURL("https://docs.google.com/document/d/19XEy7IuvIJIZ0OIWVZlIbp6GJ_ip-tRRYEQk1rrF8Js/edit?usp=sharing");
    }

    public void SelectGame()
    {
        _gameSelectMenu.SetActive(true);
    }
}
