using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMechanics : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipeArray;
    private int _activePipeID;

    //Rotate Buttons
    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;

    void Start()
    {
        
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
        _pipeArray[_activePipeID].transform.Rotate(0, 0, -15 * direction);
    }

}
