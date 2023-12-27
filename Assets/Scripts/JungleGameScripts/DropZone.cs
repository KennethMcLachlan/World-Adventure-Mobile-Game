using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private JungleMechanics _jungleMechanics;
    [SerializeField] private AudioSource _successSFX;

    private Image _thisImage;

    private bool _roundOneIsActive;
    private bool _roundTwoIsActive;
    private bool _roundThreeIsActive;


    private void Start()
    {
        _thisImage = GetComponent<Image>();
        _jungleMechanics = GameObject.Find("JungleMechanicsManager").GetComponent<JungleMechanics>();
        if (_jungleMechanics == null)
        {
            Debug.Log("jungle mechanics is null");
        }

        _successSFX = gameObject.GetComponent<AudioSource>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if (_roundOneIsActive == true)
        {
            if (eventData.pointerDrag.name == "Image04")
            {
                Debug.Log("I got number 4");
                eventData.pointerDrag.GetComponent<DragScript>()._oldPosition = _thisImage.rectTransform.localPosition;
                _jungleMechanics.RoundOneComplete();
                _successSFX.Play();
            }
        }

        if (_roundTwoIsActive == true)
        {

            if (eventData.pointerDrag.name == "Image07")
            {
                Debug.Log("I got number 7");
                eventData.pointerDrag.GetComponent<DragScript>()._oldPosition = _thisImage.rectTransform.localPosition;
                _jungleMechanics.RoundTwoComplete();
                _successSFX.Play();
            }
        }

        if (_roundThreeIsActive == true)
        {
            if (eventData.pointerDrag.name == "Image09")
            {
                Debug.Log("I got number 9");
                eventData.pointerDrag.GetComponent<DragScript>()._oldPosition = _thisImage.rectTransform.localPosition;
                _jungleMechanics.RoundThreeComplete();
                _successSFX.Play();
            }
        }

        //else
        //{
        //    _thisImage.rectTransform.localPosition = eventData.pointerDrag.GetComponent<DragScript>()._oldPosition;
        //}
    }

    public void SetRoundOne()
    {
        _roundOneIsActive = true;
    }

    public void EndRoundOne()
    {
        _roundOneIsActive = false;
    }

    public void SetRoundTwo()
    {
        _roundTwoIsActive = true;
    }

    public void EndRoundTwo()
    {
        _roundTwoIsActive = false;
    }

    public void SetRoundThree()
    {
        _roundThreeIsActive = true;
    }

    public void EndRoundThree()
    {
        _roundThreeIsActive = false;
    }

}
