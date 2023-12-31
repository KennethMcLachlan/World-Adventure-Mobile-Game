using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OceanButtons : MonoBehaviour
{

    [SerializeField] private GameObject[] _shells;

    [SerializeField] private Transform _shellLayout;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(_shells[Random.Range(0, 4)]);
            button.name = "" + i;
            button.transform.SetParent(_shellLayout, false);
        }
    }
}
