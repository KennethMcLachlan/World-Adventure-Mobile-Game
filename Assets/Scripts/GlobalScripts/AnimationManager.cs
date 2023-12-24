using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _textBoxAnim;

    private void Start()
    {
        _textBoxAnim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (_textBoxAnim != null)
        {
            _textBoxAnim.SetBool("BoxIsActive", true);
        }
    }

    public void StopAnimation()
    {
        if (_textBoxAnim != null)
        {
            _textBoxAnim.SetBool("BoxIsActive", false);
        }
    }
}
