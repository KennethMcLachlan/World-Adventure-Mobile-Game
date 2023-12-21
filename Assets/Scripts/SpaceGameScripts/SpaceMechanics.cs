using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMechanics : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipeArray;
    private int _activePipeID;
    private bool[] _isPipeLocked;

    [SerializeField] private GameObject _stars;
    [SerializeField] private AudioSource _successSFX;

    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;

    void Start()
    {
        _isPipeLocked = new bool[_pipeArray.Length];
        _successSFX = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
    }
    public void AssignPipe(int id)
    {
        _activePipeID = id;
    }

    public void RotateCurrentPipe(int direction)
    {
        if (!_isPipeLocked[_activePipeID])
        {
            _pipeArray[_activePipeID].transform.Rotate(0, 0, -15 * direction);

            SetRotationAxis();
        }
    }

    private void SetRotationAxis()
    {
        Vector3 rotation = _pipeArray[_activePipeID].GetComponent<RectTransform>().rotation.eulerAngles;

        if (rotation.z <= 1f)
        {
            _pipeArray[_activePipeID].GetComponent<Button>().enabled = false;
            _isPipeLocked[_activePipeID] = true;
            _successSFX.Play();
            StartCoroutine(StarsRoutine());
        }
        
        if (_activePipeID >=  2)
        {
            //Enable Round 2
        }

        if (_activePipeID > 6)
        {
            //Enable round 3
        }

    }

    IEnumerator StarsRoutine()
    {
        _stars.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        _stars.SetActive(false);
    }

}
