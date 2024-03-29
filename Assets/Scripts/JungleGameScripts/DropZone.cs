using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource _successSFX;

    private JungleMechanics _jungleMechanics;

    private Image _thisImage;

    private bool _roundOneIsActive;
    private bool _roundTwoIsActive;
    private bool _roundThreeIsActive;

    public Vector3 newPosition;

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
        //Round One
        if (_roundOneIsActive == true && eventData.pointerDrag.name == "Image04")
        {
            newPosition = _thisImage.rectTransform.localPosition;
            _jungleMechanics.RoundOneComplete();
            _successSFX.Play();
            
        }

        //Round Two
        if (_roundTwoIsActive == true && eventData.pointerDrag.name == "Image07")
        {
            newPosition = _thisImage.rectTransform.localPosition;
            _jungleMechanics.RoundTwoComplete();
            _successSFX.Play();
        }

        //Round Three
        if (_roundThreeIsActive == true && eventData.pointerDrag.name == "Image09")
        {
            newPosition = _thisImage.rectTransform.localPosition;
            _jungleMechanics.RoundThreeComplete();
            _successSFX.Play();
        }

        if (newPosition != null)
        {
            eventData.pointerDrag.transform.position = newPosition;
        }

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
