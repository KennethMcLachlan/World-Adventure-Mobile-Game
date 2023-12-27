using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Image _imageNumber;
    [SerializeField] private Image _imageDropZone;
    public Vector3 _oldPosition;

    private void Start()
    {
        _imageNumber = GetComponent<Image>();
        _oldPosition = _imageNumber.rectTransform.localPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var temp = _imageNumber.color;
        temp.a = 0.5f;
        _imageNumber.color = temp;
        _imageNumber.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var temp = _imageNumber.color;
        temp.a = 1.0f;
        _imageNumber.color = temp;
        _imageNumber.raycastTarget = true;
        ResetPosition();
    }

    public void ResetPosition()
    {
        _imageNumber.rectTransform.localPosition = _oldPosition;
    }
}
