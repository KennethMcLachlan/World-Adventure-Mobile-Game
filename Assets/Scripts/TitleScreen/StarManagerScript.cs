using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _stars;
    
    void Start()
    {
        StartCoroutine(StartStarsRoutine());
    }

    IEnumerator StartStarsRoutine()
    {
        yield return new WaitForSeconds(2f);
        _stars.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(_stars);

    }
}
